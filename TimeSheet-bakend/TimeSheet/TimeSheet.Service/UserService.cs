using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSheet.Common;
using TimeSheet.DTO;
using TimeSheet.IService;
using TimeSheet.Service.Entities;

namespace TimeSheet.Service
{
    public class UserService : IUserService
    {
        private readonly TSDbContext _context;
        public UserService(TSDbContext TSDbContext)
        {
            _context = TSDbContext;
        }

        public long AddNewUser(UserAddNewDTO dtoUser)
        {
            User user = new User()
            {
                EId = dtoUser.EId,
                ChiName = dtoUser.ChiName,
                EngName = dtoUser.EngName,
                Email = dtoUser.Email,
                Gender = dtoUser.Gender,
                PhoneNum = dtoUser.PhoneNum,
                Status = dtoUser.Status,
                EmployeeNo = dtoUser.EmployeeNo,
                BornDate = dtoUser.BornDate,
                //TODO:
                CreatedBy = "admin",
                CreatedDate = DateTime.Now
            };
            user.PassWordSalt = CommonHelper.CreateVerifyCode(5);
            string pwdHash = CommonHelper.CalcMD5(user.PassWordSalt + dtoUser.PassWord);
            user.PassWordHash = pwdHash;
            
            _context.Users.Add(user);
            _context.SaveChanges();

            #region old code
            //using (TSDbContext ctx =new TSDbContext())
            //{
            //    ctx.Users.Add(user);
            //    ctx.SaveChanges();
            //    return user.Id;
            //} 
            #endregion

            return user.Id;
        }
        /// <summary>
        /// get all user
        /// </summary>
        /// <returns></returns>
        public UserDTO[] GetAll()
        {
            return _context.Users.Where(p => !p.IsDeleted).Select(p => ToDTO(p)).ToArray();
        }

        public UserDTO GetById(long userId)
        {
            var user = _context.Users.SingleOrDefault(p => !p.IsDeleted && p.Id == userId);
            return ToDTO(user);
        }

        public long UpdateUser(long userId, UpdateUserDTO dtoUser)
        {
            User user = _context.Users.Where(p => p.Id == userId).SingleOrDefault();
            if(user==null)
            {
                throw new NotImplementedException();
            }
            user.EId = dtoUser.EId;
            user.EngName = dtoUser.EngName;
            user.ChiName = dtoUser.ChiName;
            user.Gender = dtoUser.Gender;
            user.Email = dtoUser.Email;
            user.PhoneNum = dtoUser.PhoneNum;
            user.EmployeeNo = dtoUser.EmployeeNo;
            user.BornDate = dtoUser.BornDate;
            user.Status = dtoUser.Status;
            //TODO:
            user.LastUpdatedBy = "admin";
            user.LastUpdatedDate = DateTime.Now;
            //context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user.Id;
        }

        public void MarkDeleted(long userId)
        {
            User user = _context.Users.Where(p => p.Id == userId).SingleOrDefault();
            if (user != null)
            {
                user.IsDeleted = true;
                user.LastUpdatedBy = "admin";
                user.LastUpdatedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }
      
        public void UpdatePwd(long userId, UserChangePasswordDTO dto)
        {
            User user = _context.Users.Where(p => p.Id == userId).SingleOrDefault();
            if (user == null)
            {
                throw new NotImplementedException();
            }

            string oldPasswordHash = CommonHelper.CalcMD5(user.PassWordSalt + dto.OldPassw0rd);
            if (oldPasswordHash != user.PassWordHash)
            {
                throw new NotImplementedException();
            }
            user.PassWordSalt = CommonHelper.CreateVerifyCode(5);
            string pwdHash = CommonHelper.CalcMD5(user.PassWordSalt + dto.NewPassw0rd);
            user.PassWordHash = pwdHash;
            _context.SaveChanges();

        }
        public void RecordLoginError(long userId)
        {
            User user = _context.Users.Where(p => p.Id == userId).SingleOrDefault();
            if (user == null)
            {
                throw new NotImplementedException();
            }
            user.LoginErrorTimes += 1;
            _context.SaveChanges();
        }

        public void ResetLoginError(long userId)
        {
            User user = _context.Users.Where(p => p.Id == userId).SingleOrDefault();
            if (user == null)
            {
                throw new NotImplementedException();
            }
            user.LoginErrorTimes = 0;
            _context.SaveChanges();
        }

        private UserDTO ToDTO(User user)
        {
            if(user==null)
            {
                return null;
            }
            UserDTO dto = new UserDTO();
            dto.Id = user.Id;
            dto.EId = user.EId;
            dto.ChiName = user.ChiName;
            dto.EngName = user.EngName;
            dto.BornDate = user.BornDate;
            dto.Gender = user.Gender;
            dto.EmployeeNo = user.EmployeeNo;
            dto.Email = user.Email;
            dto.PhoneNum = user.PhoneNum;
            dto.Status = user.Status;
            dto.LoginErrorTimes = user.LoginErrorTimes;
            dto.LastFailedAttemptDateTime = user.LastFailedAttemptDateTime;
            dto.LastLogOnDateTime = user.LastLogOnDateTime;
            dto.LastPasswordUpdateDateTime = user.LastPasswordUpdateDateTime;
            dto.IsDeleted = user.IsDeleted;
            dto.CreatedBy = user.CreatedBy;
            dto.CreatedDate = user.CreatedDate;
            dto.Id = user.Id;
            dto.LastUpdatedBy = user.LastUpdatedBy;
            dto.LastUpdatedDate = user.LastUpdatedDate;
            return dto;
        }

    }
}
