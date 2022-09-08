using AutoMapper;
using glkt.Common.Utils;
using glkt.Common.Utils.Result;
using glkt.EF;
using glkt.IService.Edu;
using glkt.Model.DTO.Edu;
using glkt.Model.Vo.Edu;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq.Expressions;
using System.Linq;
using ToPage;

namespace glkt.Edu.Controllers
{
    [Route("api/admin/edu/[controller]")]
    [ApiController]
    [SwaggerTag("讲师")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet("{index}/{size}")]
        [SwaggerOperation(Summary = "查找所有讲师")]
        public async Task<dynamic> FindAllTeacher(int index, int size)
        {
            PageList pagelist = await _teacherService.Page(index, size);

            pagelist.Data = _mapper.Map<IEnumerable<EduTeacherDto>>(pagelist.Data);

            return ApiResult.Ok(pagelist);
        }

        [HttpPost("search")]
        [SwaggerOperation(Summary = "根据筛选条件查询讲师")]
        public async Task<dynamic> FindAllTeacher(TeacherQueryVo? searchObj)
        {

            Func<EduTeacher, bool> func = null;

            if (!string.IsNullOrEmpty(searchObj.name))
            {
                func += t => t.Name == searchObj.name;
            }

            if (searchObj.level != null)
            {
                func += t => t.Level == searchObj.level;
            }

            if (searchObj.begin != null)
            {
                func += t => t.GmtCreate >= searchObj.begin;
            }

            if (searchObj.end != null)
            {
                func += t => t.GmtCreate <= searchObj.end;
            }
            Expression<Func<EduTeacher, bool>> expression = t => func.Invoke(t);
            PageList pagelist = await _teacherService.Page(searchObj.index, searchObj.size, expression);

            pagelist.Data = _mapper.Map<IEnumerable<EduTeacherDto>>(pagelist.Data);

            return ApiResult.Ok(pagelist);
        }

        [HttpGet("{id}")]
        public async Task<dynamic> GetTeacherById(string id)
        {
            EduTeacher teacher = await _teacherService.GetEntityAsync(e => e.Id == id);
            if (teacher != null)
                return ApiResult.Ok(_mapper.Map<EduTeacherDto>(teacher));
            return ApiResult.Error("未找到该讲师");
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "根据ID删除讲师")]
        public async Task<dynamic> RemoveTeacher(string id)
        {
            await _teacherService.DeleteById(id);
            return ApiResult.Ok();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "添加讲师")]
        public async Task<dynamic> CreateTeacher(EduTeacherDto teacherDto)
        {
            EduTeacher teacher = _mapper.Map<EduTeacher>(teacherDto);
            string id = Guid.NewGuid().ToString().Replace("-", "");
            teacher.GmtModified = DateTime.Now;
            teacher.GmtCreate = DateTime.Now;
            teacher.Id = id;
            if (await _teacherService.Add(teacher))
                return ApiResult.Ok();
            return ApiResult.Error();
        }


        [HttpPut("{id}")]
        public async Task<dynamic> UpdateTeacher(string id, EduTeacherDto teacherDto)
        {
            EduTeacher teacher = await _teacherService.GetEntityAsync(t => t.Id == id);
            if (teacher == null)
            {
                return ApiResult.Error("未找到要修改的讲师");
            }

            teacher.Avatar = teacherDto.Avatar;
            teacher.Intro = teacherDto.Intro;
            teacher.Career = teacherDto.Career;
            teacher.Level = teacherDto.Level;
            teacher.Name = teacherDto.Name;
            teacher.GmtCreate = DateTime.Parse(teacherDto.GmtCreate);
            teacher.Sort = teacherDto.Sort;
            teacher.GmtModified = DateTime.Now;

            if (await _teacherService.Update(teacher))
                return ApiResult.Ok();
            return ApiResult.Error("修改失败");
        }
    }
}
