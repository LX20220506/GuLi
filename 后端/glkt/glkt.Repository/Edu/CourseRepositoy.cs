using ggkt.Repository.Base;
using glkt.Common.Utils;
using glkt.EF;
using glkt.IRepository.Edu;
using glkt.Model.VO.Edu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Repository.Edu
{
    public class CourseRepositoy : RepositoryBase<EduCourse>, ICourseRepository
    {
        private readonly GuLiDbContext _dbContext;

        public CourseRepositoy(GuLiDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// course、teacher、subject三张表关联，
        /// 返回前端course列表所需要的数据
        /// </summary>
        /// <returns></returns>
        public async Task<PageList> CourseJoinSubjectJoinTeacher(int index,int size,EduCourseSearchRequest? search) {
            var course = _dbContext.EduCourses.Where(c=>true);

            if (!string.IsNullOrEmpty(search.SubjectParentId))
            {
                course = course.Where(s => s.SubjectParentId == search.SubjectParentId);
                if (!string.IsNullOrEmpty(search.SubjectId))
                {
                    course = course.Where(s => s.SubjectId == search.SubjectId);
                }
            }

            if (!string.IsNullOrEmpty(search.Title))
            {
                course = course.Where(s => s.Title == search.Title);
            }

            if (!string.IsNullOrEmpty(search.TeacherId))
            {
                course = course.Where(s => s.TeacherId == search.TeacherId);
            }

            // 分页
            course = course.OrderBy(s => s.GmtCreate).Skip((index - 1) * size).Take(size);


            // 先和teacher表关联，找到老师名称
            var data = course.Join(_dbContext.EduTeachers, c => c.TeacherId, t => t.Id, (c, t) => new
            {
                course = c,
                TeacherName = t.Name
            })
                // 再和subject表关联，找到二级分类
                .Join(_dbContext.EduSubjects, c => c.course.SubjectId, s => s.Id, (c, s) => new
                {
                    course = c.course,
                    TeacherName = c.TeacherName,
                    subjectTitle = s.Title,
                    SubjectId = s.Id
                })
                // 最后再和subject表关联，找一级分类；        
                .Join(_dbContext.EduSubjects, c => c.course.SubjectParentId, s => s.Id, (c, s) => new
                {
                    // 拿到所有需要的数据后，整理需要的数据
                    id = c.course.Id,
                    cover = c.course.Cover,
                    title = c.course.Title,
                    subjectParentTitle = s.Title,
                    subjectTitle = c.subjectTitle,
                    lessonNum = c.course.LessonNum,
                    viewCount = c.course.ViewCount,
                    buyCount = c.course.BuyCount,
                    teacherName = c.TeacherName,
                    price = c.course.Price,
                    status = c.course.Status,
                    createTime = c.course.GmtCreate
                });
            var list = await data.ToListAsync();


            return new PageList(data, index, size, list.Count);
        }

        public async Task<CoursePublishResponse> GetCoursePublishVoById(string id)
        {
            var course = _dbContext.EduCourses.Where(c => c.Id == id);
            var data = await course.Join(_dbContext.EduTeachers, c => c.TeacherId, t => t.Id, (c, t) => new
            {
                course = c,
                TeacherName = t.Name
            })
                // 再和subject表关联，找到二级分类
                .Join(_dbContext.EduSubjects, c => c.course.SubjectId, s => s.Id, (c, s) => new
                {
                    course = c.course,
                    TeacherName = c.TeacherName,
                    subjectTitle = s.Title,
                    SubjectId = s.Id
                })
                // 最后再和subject表关联，找一级分类；        
                .Join(_dbContext.EduSubjects, c => c.course.SubjectParentId, s => s.Id, (c, s) => new
                {
                    // 拿到所有需要的数据后，整理需要的数据
                    cover = c.course.Cover,
                    title = c.course.Title,
                    SubjectLevelOne = s.Title,
                    SubjectLevelTwo = c.subjectTitle,
                    lessonNum = c.course.LessonNum,
                    teacherName = c.TeacherName,
                    price = c.course.Price,
                }).SingleOrDefaultAsync();

            return  new CoursePublishResponse
            {
                Cover = data.cover,
                Title = data.title,
                LessonNum = (int)data.lessonNum,
                Price = data.price,
                SubjectLevelOne = data.SubjectLevelOne,
                SubjectLevelTwo = data.SubjectLevelTwo,
                TeacherName = data.teacherName
            };
        }
    }
}
