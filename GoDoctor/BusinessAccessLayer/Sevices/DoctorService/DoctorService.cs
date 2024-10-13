using BusinessAccessLayer.DataViews.AuthView;
using BusinessAccessLayer.DataViews.DoctorView;
using BusinessAccessLayer.Sevices.AuthService;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.DoctorRepo;
using DataAccessLayer.UnitOfWorkRepo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthService authService;

        public DoctorService(IUnitOfWork unitOfWork, IAuthService authService)
        {

            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }
        #region Add Doc 
        public async Task<CreateResult> AddDoctor(AddDoctorView addDoctorView)
        {
            using (var t = await unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    // Creating signup object for user registration
                    SignupView signupView = new SignupView()
                    {
                        City = addDoctorView.City,
                        Firstname = addDoctorView.Firstname,
                        Lastname = addDoctorView.Lastname,
                        Email = addDoctorView.Email,
                        Password = addDoctorView.Password,
                        Role = "Doctor"
                    };

                    // Register the doctor (user) first
                    var result = await authService.Regestration(signupView);
                    if (!result.IsAuth)
                    {
                        await t.RollbackAsync();  // Rollback if registration fails
                        return new CreateResult()
                        {
                            Errors = result.Errors,
                            IsAdded = false,
                        };
                    }

                    // Create Doctor object with Clinic
                    Docktor doctor = new Docktor()
                    {
                        ApplicationUserId = result.UserId,
                        Clinic =
                    new Clinic()
                    {
                        ClinicAddress = addDoctorView.ClinicAddress,
                        ClinicCity = addDoctorView.ClinicCity,
                        PhoneNumber = addDoctorView.PhoneNumber,
                        CreatedDate = DateTime.Now,
                        IsDeleted = false,

                    },
                        CreatedDate = DateTime.Now,
                        IsDeleted = false,
                        Price = addDoctorView.Price,
                        Description = addDoctorView.Description,
                        SpecialtyId = addDoctorView.SpecialtyId,
                        IsValid = false,
                        ImgeUrl = await HelperClasses.Helper.SaveImages(addDoctorView.Image, HelperClasses.Helper.ImagesDoctorPath, HelperClasses.Helper.URLDoctor)
                    };
                    await unitOfWork.doctorRepository.AddAsync(doctor);
                    // Add the doctor to the database (assumed that Complete does this)
                    var rowsAffected = await unitOfWork.CompleteAsync();
                    if (rowsAffected == 0)
                    {
                        await t.RollbackAsync();  // Rollback if no rows were affected
                        return new CreateResult()
                        {
                            Errors = "An error occurred while adding the doctor.",
                            IsAdded = false
                        };
                    }

                    // Commit transaction
                    await t.CommitAsync();
                    return new CreateResult()
                    {
                        IsAdded = true
                    };
                }
                catch (Exception ex)
                {
                    await t.RollbackAsync();  // Rollback in case of any exception
                    return new CreateResult()
                    {
                        Errors = $"Error: {ex.Message}", // Return more informative error
                        IsAdded = false
                    };
                }
            }
        }
        #endregion
        public async Task<IEnumerable<DoctorSearchViewModel>> DoctorSearch(int specialty, string governorate, string doctor, int page)
        {
            var result = await unitOfWork.doctorRepository.GetDocktors(specialty, governorate, doctor, page);
            var count = await unitOfWork.doctorRepository.GetDocktorsCount(specialty, governorate, doctor, page);
            if (count == 0)
            {
                return Enumerable.Empty<DoctorSearchViewModel>();
            }
            return result.Select(x => new DoctorSearchViewModel()
            {
                CurrentPage = page,
                Description = x.Description,
                Name = string.Concat(x.ApplicationUser.FirstName, x.ApplicationUser.LastName),
                specialtyDescription = x.Specialty.Description,
                specialtyName = x.Specialty.Name,
                image = x.ImgeUrl,
                Id = x.Id,
                TotalPages = count,

            });
        }

        public async Task<DoctorDetailsView?> GetDocterById(int DocId)
        {
               var result = await unitOfWork.doctorRepository.GetDocterById(DocId);
            return new DoctorDetailsView()
            {
                Id = result.Id,
                specialtyDescription = result.Specialty.Description,
                specialtyName = result.Specialty.Name,
                image = result.ImgeUrl,
                Name = result.ApplicationUser.FirstName + " " + result.ApplicationUser.LastName,
                Description = result.Specialty.Description,
                ClinicAddress = result.Clinic.ClinicAddress,
                ClinicCity = result.Clinic.ClinicCity,
                commentViews = result.Comments.Select(c => new DataViews.CommentView.DoctorCommentsView()
                {
                    Comment = c.CommentContent,
                    UserName = c.User.FirstName + " " + c.User.LastName,
                    CommentAt = c.CreatedDate,
                    Id = c.Id,
                })
            };

        }
    }
}
