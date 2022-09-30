using AutoMapper;
using ggkt.Service.Base;
using glkt.Common.Utils;
using glkt.EF;
using glkt.IRepository.Base;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using glkt.Model.VO.Edu;
using glkt.Repository.Edu;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Service.Edu
{
    public class CourseService : ServiceBase<EduCourse>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ICourseDescriptionRepositoy _courseDescriptionRepositoy;
        private readonly IChapterService _chapterService;
        private readonly IVideorService _videorService;

        public CourseService(ICourseRepository courseRepository, IMapper mapper, ICourseDescriptionRepositoy courseDescriptionRepositoy, IChapterService chapterService, IVideorService videorService) : base(courseRepository)
        {
            this._courseRepository = courseRepository;
            this._mapper = mapper;
            this._courseDescriptionRepositoy = courseDescriptionRepositoy;
            _chapterService = chapterService;
            _videorService = videorService;
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PageList> PageList(int index, int size, EduCourseSearchRequest? search)
        {
            return await _courseRepository.CourseJoinSubjectJoinTeacher(index,size,search);
        }


        /// <summary>
        /// 通过课程id，拿到课程信息
        /// </summary>
        /// <param name="id">课程id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<EduCourseInfoForm> getCourseInfoFormById(string id)
        {
            var course = await _courseRepository.GetAllAsync().Where(s => s.Id == id).SingleOrDefaultAsync();

            EduCourseInfoForm courseInfoForm = _mapper.Map<EduCourseInfoForm>(course);

            EduCourseDescription courseDescription = await _courseDescriptionRepositoy.GetAllAsync().Where(s => s.Id == id).SingleOrDefaultAsync();

            courseInfoForm.Description = courseDescription.Description;
            return courseInfoForm;
        }

       

        /// <summary>
        /// 保存课程和课程详情信息
        /// </summary>
        /// <param name="courseInfoForm"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> saveCourseInfo(EduCourseInfoForm courseInfoForm)
        {
            EduCourse course = _mapper.Map<EduCourse>(courseInfoForm);
            course.Status = EduCourse.COURSE_DRAFT;

            string courseId = Guid.NewGuid().ToString().Replace("-", "");
            course.Id = courseId;
            _courseRepository.Add(course);

            EduCourseDescription courseDescription = new EduCourseDescription{
                Id = course.Id,
                Description = courseInfoForm.Description
            };

            _courseDescriptionRepositoy.Add(courseDescription);

            int check = await _courseRepository.SaveAsync();

            if (check<2)
            {
                throw new Exception("课程信息保存失败");
            }

            return courseId;
        }


        /// <summary>
        /// 修改课程信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseInfoForm"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateCourseInfo(EduCourseInfoForm courseInfoForm)
        {
            var course = await _courseRepository.GetEntityAsync(c => c.Id == courseInfoForm.Id);

            var courseDescription = await _courseDescriptionRepositoy.GetEntityAsync(c => c.Id == courseInfoForm.Id);

            course.SubjectParentId = courseInfoForm.SubjectParentId;
            course.SubjectId=courseInfoForm.SubjectId;
            course.TeacherId = courseInfoForm.TeacherId;
            course.LessonNum = (uint)courseInfoForm.LessonNum;
            course.Price = courseInfoForm.Price;
            course.Cover = courseInfoForm.Cover;
            course.Title = courseInfoForm.Title;

            courseDescription.Description = courseInfoForm.Description;

            await _courseRepository.SaveAsync();
        }


        public async Task RemoveById(string id)
        {
            // 根据id删除所有小节视频
            await _videorService.RemoveVideorByCourseId(id);
            // 根据id删除所有章节信息
            await _chapterService.RemoveChapterByCourseId(id);  

            var course = await base.GetEntityAsync(c => c.Id == id);

            await base.Delete(course);

           await  _courseRepository.SaveAsync();
        }

        public Task<CoursePublishResponse> GetCoursePublishVoById(string id)
        {
            return _courseRepository.GetCoursePublishVoById(id);
        }

        public async Task PublishCourse(string courseId)
        {
            EduCourse course = await base.GetEntityAsync(c=>c.Id==courseId);

            course.Status= EduCourse.COURSE_NORMAL;

            await _courseRepository.SaveAsync();
        }
    }
}
