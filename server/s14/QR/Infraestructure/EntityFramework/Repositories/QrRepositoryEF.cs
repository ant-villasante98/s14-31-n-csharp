using Microsoft.EntityFrameworkCore;
using S14.QR.Domain;
using S14.QR.Infrastructure.EntityFramework.Persistance;

namespace S14.QR.Infrastructure.EntityFramework.Repositories;

public class QrRepositoryEF : IQrRepository
{
    private readonly QrSystemContext _context;

    public QrRepositoryEF(QrSystemContext context)
    {
        _context = context;
    }

    public async Task<Qr> AddAsync(Qr model)
    {
        _context.Add(model).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        Qr? qr = await FindByIdAsync(id);
        if (qr is null)
        {
            throw new ArgumentException("No se encontro el recurso");
        }

        await DeleteAsync(qr);
    }

    public async Task DeleteAsync(Qr model)
    {
        _context.Remove(model).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Qr>> FindAllAsync()
    {
        return await _context.Qrs.ToListAsync();
    }

    public async Task<Qr?> FindByIdAsync(Guid id)
    {
        return await _context.Qrs.FindAsync(id);
    }

    public async Task<Qr?> FindByOrderAsync(int orderId)
    {
        return await _context.Qrs.FirstOrDefaultAsync(m => m.OrderId == orderId);
    }

    public async Task<Qr> UpdateAsync(Qr model)
    {
        _context.Update(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return model;
    }
}