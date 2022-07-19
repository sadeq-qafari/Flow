using System;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface ILogService
    {
        Task AddAsync(Exception ex);
    }
}