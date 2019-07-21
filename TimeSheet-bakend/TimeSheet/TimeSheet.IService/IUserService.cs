using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.DTO;

namespace TimeSheet.IService
{
    public interface IUserService: IServiceSupport
    {
        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        long AddNewUser(UserAddNewDTO dtoUser);

        /// <summary>
        /// update user info
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        long UpdateUser(long userId, UpdateUserDTO dtoUser);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        void MarkDeleted(long userId);

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        UserDTO[] GetAll();

        /// <summary>
        /// get user info by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDTO GetById(long userId);

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPassword"></param>
        void UpdatePwd(long userId, UserChangePasswordDTO dto);

        /// <summary>
        /// log login failed times
        /// </summary>
        /// <param name="id"></param>
        void RecordLoginError(long userId);

        /// <summary>
        /// reset login failed info
        /// </summary>
        /// <param name="id"></param>
        void ResetLoginError(long userId);
    }
}
