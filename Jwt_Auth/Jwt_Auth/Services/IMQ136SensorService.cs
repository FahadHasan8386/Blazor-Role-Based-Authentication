using Jwt_Auth.Entities;
using Jwt_Auth.Models;

namespace Jwt_Auth.Services
{
    public interface IMQ136SensorService
    {
        Task<IEnumerable<MQ136Sensor>> GetAllAsync();
        Task<MQ136Sensor?> GetByIdAsync(long  id);
        Task<MQ136Sensor> AddAsync(MQ136SensorDto dto);
        Task<bool> DeleteAsync(long id);
    }
}
