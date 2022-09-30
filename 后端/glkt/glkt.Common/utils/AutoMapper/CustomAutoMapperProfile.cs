using AutoMapper;
using glkt.EF;
using glkt.Model.Vo.Edu;
using glkt.Model.VO.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.Utils.AutoMapper
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            // 讲师信息映射
            base.CreateMap<EduTeacher, EduTeacherResponse>() // e表示EduTeacher；dto表示EduTeacherDto
                .ForMember(dto => dto.GmtCreate, // 将EduTeacher的DateTime类型映射为string类型
                opt => opt.MapFrom(
                    e => e.GmtCreate.ToString("yyyy-MM-dd HH:mm:ss")));
            
            base.CreateMap<EduTeacherResponse, EduTeacher>()
                .ForMember(e => e.GmtCreate, // 将EduTeacherDto的string类映射为DateTime类型
                opt => opt.MapFrom(
                    dto =>DateTime.Parse(dto.GmtCreate)));
            //base.CreateMap<IEnumerable<EduTeacher>, IEnumerable<EduTeacherDto>>();



            // 课程信息映射
            base.CreateMap<EduCourseInfoForm, EduCourse>();
            base.CreateMap<EduCourse, EduCourseInfoForm>();


            // 课程信息详情映射(将EduCourseInfoForm映射为EduCourseDescription)
            base.CreateMap<EduCourseInfoForm, EduCourseDescription>();

            // 章节信息映射(将EduChapterRequest映射为EduChapter)
            base.CreateMap<EduChapterRequest, EduChapter>();

            // 小节信息映射(将EduVideoInfoForm映射为EduVideo)
            base.CreateMap<EduVideoInfoForm, EduVideo>()
                .ForMember(v => v.IsFree, 
                opt => opt.MapFrom(
                    dto => dto.Free)
                );


        }
    }
}
