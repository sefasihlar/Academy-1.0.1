﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFreamwork
{
    public class EfCoreLessonRepository : EfCoreGenericRepository<Lesson, AcademyContext>, ILessonDal
    {
    }
}
