using MultiThreadingDemo.Domain.Context;
using MultiThreadingDemo.Domain.Models;
using MutiThreadingDemo.DataAccess.Dtos;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutiThreadingDemo.DataAccess.Repositories
{
    public class ThreadProcessorRepository
    {
        private Logger _logger;
        public ThreadProcessorRepository()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void GenerateUserDetails()
        {
            try
            {
                using (var _context = new MultiThreadingDemoContext())
                {
                    var comments = _context.Comments
                        .Where(c => c.HasGeneratedUserDetail == false).Take(10).ToList();

                    if (comments.Any())
                    {
                        foreach (var comment in comments)
                        {
                            var userDetail = new UserDetail
                            {
                                CommentId = comment.Id,
                                Name = comment.Name,
                                Email = comment.Email,
                                DateGenerated = DateTime.Now.ToString()
                            };

                            _context.UserDetails.Add(userDetail);
                            _context.SaveChanges();

                            _logger.Info("Just Created a user detail whose comment Id is ==> " + comment.Id);

                            var commentToUpdate = _context.Comments
                                .Where(c => c.Id == comment.Id).FirstOrDefault();

                            commentToUpdate.HasGeneratedUserDetail = true;
                            _context.SaveChanges();

                            _logger.Info("Just updated HasGeneratedUserDetail column to true for comment whose comment Id is ==> " + comment.Id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.InnerException);
                _logger.Error(ex.StackTrace);
            }
        }

        public void GenerateCollectiveInformation()
        {
            try
            {
                using (var _context = new MultiThreadingDemoContext())
                {
                    var userDetails = _context.UserDetails.Where(u => u.IsBridged == false).Take(5).ToList();

                    if (userDetails.Any())
                    {
                        foreach (var userDetail in userDetails)
                        {
                            var comment = _context.Comments.Where(c => c.Id == userDetail.CommentId).FirstOrDefault();

                            var collectiveInformation = new CollectiveInformation
                            {
                                PostId = comment.PostId,
                                CommentId = userDetail.CommentId,
                                Name = userDetail.Name,
                                Email = userDetail.Email,
                                Body = comment.Body,
                                HasGeneratedUserDetail = comment.HasGeneratedUserDetail,
                                DateUserDetailWasGenerated = userDetail.DateGenerated,
                                DateBridged = DateTime.Now.ToString()
                            };

                            var collectiveInformationJson = JsonConvert.SerializeObject(collectiveInformation);

                            var userComment = new UserComment
                            {
                                UserId = userDetail.Id,
                                CollectiveInformationJson = collectiveInformationJson,
                                DateGenerated = DateTime.Now.ToString()
                            };

                            _context.UserComments.Add(userComment);
                            _context.SaveChanges();

                            _logger.Info("Just created a user comment for a user whose user detail id is ==> " + userDetail.Id);

                            var userDetailToUpdate = _context.UserDetails
                                .Where(u => u.Id == userDetail.Id).FirstOrDefault();

                            userDetailToUpdate.IsBridged = true;
                            _context.SaveChanges();

                            _logger.Info("Just updated IsBridged column to true for a user whose user detail id is ==> " + userDetail.Id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.InnerException);
                _logger.Error(ex.StackTrace);
            }
        }

        public void ProcessNamesWithNullValue()
        {
            try
            {
                using (var _context = new MultiThreadingDemoContext())
                {
                    var comment = _context.Comments.Where(c => c.Name == null).FirstOrDefault();

                    if (comment != null)
                    {
                        comment.Name = "Replaced the null value here with a valid string";
                        _context.SaveChanges();

                        _logger.Info("Just replaced a column with null value with a valid text for a comment whose comment Id is ==> " + comment.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.InnerException);
                _logger.Error(ex.StackTrace);
            }
        }
    }
}