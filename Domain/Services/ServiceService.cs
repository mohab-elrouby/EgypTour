using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceService : ICrudService<ServiceDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public void Create(ServiceDTO serviceDto)
        {
            Service service = new Service(serviceDto.Name,
                serviceDto.Description,
                serviceDto.WorkingHoursStart,
                serviceDto.WorkingHoursEnd,serviceDto.phone,
                serviceDto.Adress);
            _unitOfWork._services.Add(service);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork._services.Delete(id);
            _unitOfWork.Commit();
        }

        public ServiceDTO Get(int id)
        {
            Service service = _unitOfWork._services.Find(predicate :i=>i.Id==id,
                includeProperties: "Reviews.Reviwer").FirstOrDefault();

            ServiceDTO serviceDTO = ServiceDTO.FromService(service);

            return serviceDTO;
        }

        public void Update(ServiceDTO entity)
        {
            Service service = _unitOfWork._services.GetById(entity.Id);
            service.Update(entity);
            _unitOfWork._services.Update(service);
            _unitOfWork.Commit();
        }
    }
}
