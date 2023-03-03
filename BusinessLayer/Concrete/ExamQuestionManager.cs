﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ExamQuestionManager : IExamQuestionService
	{
		private readonly IExamQuestionDal _examQuestionDal;

		public ExamQuestionManager(IExamQuestionDal examQuestionDal)
		{
			_examQuestionDal = examQuestionDal;
		}

		public void Create(ExamQuestions entity)
		{
			_examQuestionDal.Create(entity);
		}

		public void Create(ExamQuestions entity, int questionId)
		{
			_examQuestionDal.Create(entity, questionId);
		}

		public void Delete(ExamQuestions entity)
		{
			_examQuestionDal.Delete(entity);
		}

		public void DeleteFormExamQuestion(ExamQuestions entity, int questionId)
		{
			_examQuestionDal.DeleteFromExamQuestion(entity,questionId);
		}


		public List<ExamQuestions> GetAll()
		{
			return _examQuestionDal.GetAll().ToList();
		}

		public ExamQuestions GetById(int id)
		{
			return _examQuestionDal.GetById(id);
		}

		public void Update(ExamQuestions entity)
		{
			_examQuestionDal.Update(entity);
		}
	}
}