using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Service;
using TimeSheet.Service.Entities;

namespace TimeSheet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
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
            //            Email = "chengcheng.yue@accenture.com",
            //            CreatedBy = "admin",
            //            PassWordSalt = "salt",
            //            PassWordHash = "hash",
            //            PhoneNum = "01234"
            //        },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "赵越",
            //        EngName = "Zhao Yue",
            //        EId = "yue.c.zhao",
            //        Email = "yue.c.zhao@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "李平平",
            //        EngName = "Li PingPing",
            //        EId = "pingping.b.li",
            //        Email = "pingping.b.li@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "韩卓君",
            //        EngName = "Han ZhuoJun",
            //        EId = "zhuojun.han",
            //        Email = "zhuojun.han@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "王玉莹",
            //        EngName = "Echo",
            //        EId = "yuying.c.wang",
            //        Email = "yuying.c.wang@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "张琪",
            //        EngName = "Caitlyn",
            //        EId = "qi.h.zhang",
            //        Email = "qi.h.zhang@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "李坚",
            //        EngName = "Nut",
            //        EId = "jian.f.li",
            //        Email = "jian.f.li@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "孙岩",
            //        EngName = "Winnie",
            //        EId = "y.g.sun",
            //        Email = "y.g.sun@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "王尧",
            //        EngName = "Emily",
            //        EId = "yao.i.wang",
            //        Email = "yao.i.wang@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    },
            //    new Service.Entities.User()
            //    {
            //        ChiName = "刘欣",
            //        EngName = "CIndy",
            //        EId = "xin.q.liu",
            //        Email = "xin.q.liu@accenture.com",
            //        CreatedBy = "admin",
            //        PassWordSalt = "salt",
            //        PassWordHash = "hash",
            //        PhoneNum = "01234"
            //    }
            //        );
            //    context.SaveChanges();
            //} 
            #endregion
            List<User> users = new List<User>();
            using (TSDbContext context =new TSDbContext())
            {
                users = context.Users.ToList();
            }
            return users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = new User();
            using (TSDbContext context = new TSDbContext())
            {
                user = context.Users.Where(p => p.Id == id).SingleOrDefault();
            }
            return user;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            using(TSDbContext context =new TSDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            using (TSDbContext context = new TSDbContext())
            {
                User dbUser = context.Users.Where(p => p.Id == id).SingleOrDefault();
                if(user!=null)
                {
                    dbUser.EngName = user.EngName;
                    dbUser.ChiName = user.ChiName;
                    dbUser.Email = user.Email;
                    dbUser.PhoneNum = user.PhoneNum;
                    //context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (TSDbContext context = new TSDbContext())
            {
                User user = context.Users.Where(p => p.Id == id).SingleOrDefault();
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
