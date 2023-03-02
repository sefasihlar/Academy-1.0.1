using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ExamAnswerManager : IExamAnswerService
	{
		private readonly IExamAnswerDal _examAnswerDal;

		public ExamAnswerManager(IExamAnswerDal examAnswerDal)
		{
			_examAnswerDal = examAnswerDal;
		}

		public void Create(ExamAnswers entity)
		{
			_examAnswerDal.Create(entity);	
		}

		public void Delete(ExamAnswers entity)
		{
			_examAnswerDal.Delete(entity);
		}

		public List<ExamAnswers> GetAll()
		{
			return _examAnswerDal.GetAll().ToList();
		}

		public ExamAnswers GetById(int id)
		{
			return _examAnswerDal.GetById(id);
		}

		public void Update(ExamAnswers entity)
		{
			_examAnswerDal.Update(entity);
		}
	}
}
