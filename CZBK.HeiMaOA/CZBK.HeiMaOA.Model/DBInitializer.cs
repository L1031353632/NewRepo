using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.Model
{
    //我们的数据初始化类继承了一个名为DropCreateDatabaseAlways的泛型类，这个类的作用就像它的名字，每次程序运行时都会删除并重新创建数据库，这样方便我们测试。
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var students = new List<Worker>
            {
                new Worker{FirstName="Andy",LastName="George",Sex = Sex.Male},
                new Worker{FirstName="Laura",LastName="Smith",Sex = Sex.Female},
                new Worker{FirstName="Jason",LastName="Black",Sex = Sex.Male},
                new Worker{FirstName="Linda",LastName="Queen",Sex = Sex.Female},
                new Worker{FirstName="James",LastName="Brown", Sex = Sex.Male}
            };

            students.ForEach(s => context.Workers.Add(s));
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
