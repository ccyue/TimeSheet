using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeSheet.Common;
using TimeSheet.DTO;
using TimeSheet.IService;
using TimeSheet.Service;
using TimeSheet.Service.Entities;

namespace TimeSheet.API.Controllers.v2
{
    //[Route("api/v2/[controller]")]
    //[ApiController]
    public class UsersController : ControllerBase
    {

        //public IUserService userService { get; set; }


        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/users
        [HttpGet]
        public ActionResult<ResponseResult> Get()
        {
            #region create data
            //using (TSDbContext context = new TSDbContext())
            //{
            //    context.Database.EnsureCreated();
            //    context.Users.AddRange(
            //        new Service.Entities.User()
            //        {
            //            ChiName = "岳程程",
            //            EngName = "Yue ChengCheng",
            //            EId = "chengcheng.yue",
            //            Gender = false,
            //            Email = "chengcheng.yue@accenture.com",
            //            CreatedBy = "admin",
            //            PassWordSalt = "salt",
            //            PassWordHash = "hash",
            //            PhoneNum = "01234",
            //            BornDate = DateTime.Now,
            //            EmployeeNo = "12345678"
            //        },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "赵越",
            //        EngName = "Zhao Yue",
            //        EId = "yue.c.zhao",
            //        Gender = true,
            //        Email = "yue.c.zhao@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "李平平",
            //        EngName = "Li PingPing",
            //        EId = "pingping.b.li",
            //        Gender = false,
            //        Email = "pingping.b.li@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "韩卓君",
            //        EngName = "Han ZhuoJun",
            //        EId = "zhuojun.han",
            //        Gender = false,
            //        Email = "zhuojun.han@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "王玉莹",
            //        EngName = "Echo",
            //        EId = "yuying.c.wang",
            //        Gender = false,
            //        Email = "yuying.c.wang@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "张琪",
            //        EngName = "Caitlyn",
            //        EId = "qi.h.zhang",
            //        Gender = false,
            //        Email = "qi.h.zhang@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "李坚",
            //        EngName = "Nut",
            //        EId = "jian.f.li",
            //        Gender = true,
            //        Email = "jian.f.li@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "孙岩",
            //        EngName = "Winnie",
            //        EId = "y.g.sun",
            //        Gender = false,
            //        Email = "y.g.sun@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "王尧",
            //        EngName = "Emily",
            //        EId = "yao.i.wang",
            //        Gender = false,
            //        Email = "yao.i.wang@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "刘欣",
            //        EngName = "CIndy",
            //        EId = "xin.q.liu",
            //        Gender = false,
            //        Email = "xin.q.liu@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234",
            //        BornDate = DateTime.Now,
            //        EmployeeNo = "12345678"
            //    }
            //        );
            //    context.SaveChanges();
            //}
            #endregion

            #region old code
            //List<User> users = new List<User>();
            //using (TSDbContext context =new TSDbContext())
            //{
            //    users = context.Users.ToList();
            //} 
            //return users;
            #endregion

            var users = _userService.GetAll().Take(5);
            return new ResponseResult()
            {
                Status = "ok",
                Data = users
            };         
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<ResponseResult> Get(long id)
        {
            var user = _userService.GetById(id);
            return new ResponseResult()
            {
                Status = "ok",
                Data = user
            };
        }

        // POST api/users
        [HttpPost]
        public ActionResult<ResponseResult> Post([FromBody] UserAddNewDTO user)
        {
            long userId =  _userService.AddNewUser(user);
            return new ResponseResult()
            {
                Status = "ok",
                Data = userId
            };
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public ActionResult<ResponseResult> Put(long id, [FromBody] UpdateUserDTO user)
        {
            long userId = _userService.UpdateUser(id, user);
            return new ResponseResult()
            {
                Status = "ok",
                Data = userId
            };
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<ResponseResult> Delete(long id)
        {
            _userService.MarkDeleted(id);
            return new ResponseResult()
            { Status = "ok" };
        }
    }
}
