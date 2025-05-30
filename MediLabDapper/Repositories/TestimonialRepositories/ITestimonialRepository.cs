﻿using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.TestimonialDtos;

namespace MediLabDapper.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<IEnumerable<ResultTestimonialDto>> GetAllAsync();
        Task<GetByIdTestimonialDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteAsync(int id);
    }
}
