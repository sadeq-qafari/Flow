using Autofac;
using AutoMapper;
using Common.Events;
using Common.Models.log;
using EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class LogService : ILogService
    {
        private readonly IEventBus _eventBus;
        private readonly IMapper _mapper;
        public LogService(IEventBus eventBus, IMapper mapper)
        {
            _eventBus = eventBus;
            _mapper = mapper;
        }
        public async Task AddAsync (Exception ex)
        {
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    IEventBus _eventBus = scope.Resolve<IEventBus>();
            //    IMapper _mapper = scope.Resolve<IMapper>();

            //    var evt = new LoggerMessageIntegrationEvent(_mapper.Map<LogException>(ex));
            //     _eventBus.Publish(evt);
            //}
          await Task.Run(() => { 
                if (ex != null)
                {
                    var evt = new LoggerMessageIntegrationEvent(_mapper.Map<LogException>(ex));
                    _eventBus.Publish(evt);
                }
            });
        }


    }
}
