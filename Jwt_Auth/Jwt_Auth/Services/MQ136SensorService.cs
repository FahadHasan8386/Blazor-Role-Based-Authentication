using Jwt_Auth.Data;
using Jwt_Auth.Entities;
using Jwt_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Jwt_Auth.Services
{
    public class MQ136SensorService(UserDbContext context) : IMQ136SensorService
    {
        public async Task<IEnumerable<MQ136Sensor>> GetAllAsync()
        {
            return await context.MQ136Sensors.ToListAsync();
        }

        public async Task<MQ136Sensor?> GetByIdAsync(long id)
        {
            return await context.MQ136Sensors.FindAsync(id);
        }

        public async Task<MQ136Sensor> AddAsync(MQ136SensorDto dto)
        {
            var sensor = new MQ136Sensor
            {
                H2SLevel = dto.H2SLevel
            };

            context.MQ136Sensors.Add(sensor);
            await context.SaveChangesAsync();

            return sensor;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var sensor = await context.MQ136Sensors.FindAsync(id);

            if (sensor == null)
                return false;

            context.MQ136Sensors.Remove(sensor);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
