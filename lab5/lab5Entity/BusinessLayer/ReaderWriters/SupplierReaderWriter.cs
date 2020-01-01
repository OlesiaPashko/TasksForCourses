﻿using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ReaderWriters
{
    public class SupplierReaderWriter : IDataReaderWriter<SupplierDTO>
    {
        private UnitOfWork unitOfWork;
        private IMapper mapper;

        public SupplierReaderWriter()
        {
            unitOfWork = new UnitOfWork();
            mapper = MapperConfigurationClass.Configure();
        }
        public void Create(SupplierDTO item)
        {
            Supplier supplier = mapper.Map<SupplierDTO, Supplier>(item);
            unitOfWork.Suppliers.Create(supplier);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            unitOfWork.Suppliers.Delete(id);
            unitOfWork.Save();
        }

        public SupplierDTO Get(int id)
        {
            Supplier Supplier = unitOfWork.Suppliers.Get(id);
            return mapper.Map<Supplier, SupplierDTO>(Supplier);
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(unitOfWork.Suppliers.GetAll());
        }

        public IEnumerable<SupplierDTO> Find(SupplierDTO elem)
        {
            IEnumerable<Supplier> suppliers = unitOfWork.Suppliers.Find(x => x.Id == elem.Id);
            return mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(suppliers);
        }

        public void Update(SupplierDTO item)
        {
            Supplier prod = mapper.Map<SupplierDTO, Supplier>(item);
            unitOfWork.Suppliers.Update(prod);
            unitOfWork.Save();
        }
    }
}