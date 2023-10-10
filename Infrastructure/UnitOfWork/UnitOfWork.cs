using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using Infrastructure.Data.Configuration;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AnimalsContext _context;
    private PaisRepository _paises;
    private CiudadRepository _ciudades;
    private DepartamentoRepository _departamentos;
    private ClienteRepository _clientes;
    private CitaRepository _citas;
    private MascotaRepository _mascotas;
    private RazaRepository _razas;
    private ServicioRepository _servicios;
    private ClienteDirRepository _clientesDirs;
    private ClienteTelRepository _clientesTels;
    public object ciudades;

    public IPaisRepository Paises
    {
        get
        {
            if(_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }
    public ICiudadRepository Ciudades
    {
        get
        {
            if(_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }
    public IDepartamentoRepository Departamentos
    {
        get
        {
            if(_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }
    public IClienteRepository Clientes
    {
        get
        {
            if(_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }
    public IMascotaRepository Mascotas
    {
        get
        {
            if(_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }
    public IRazaRepository Razas
    {
        get
        {
            if(_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }
    public IServicioRepository Servicios
    {
        get
        {
            if(_servicios == null)
            {
                _servicios = new ServicioRepository(_context);
            }
            return _servicios;
        }
    }
    public IClienteTelRepository ClientesTels
    {
        get
        {
            if(_clientesTels == null)
            {
                _clientesTels = new ClienteTelRepository(_context);
            }
            return _clientesTels;
        }
    }
    public IClienteDirRepository ClientesDirs
    {
        get
        {
            if(_clientesDirs == null)
            {
                _clientesDirs = new ClienteDirRepository(_context);
            }
            return _clientesDirs;
        }
    }
    public ICitaRepository Citas
    {
        get
        {
            if(_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }
    public UnitOfWork(AnimalsContext context)
    {
        _context = context;
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
