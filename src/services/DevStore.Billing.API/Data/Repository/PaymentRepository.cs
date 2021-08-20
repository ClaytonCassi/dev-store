using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevStore.Billing.API.Models;
using DevStore.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Billing.API.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AddPayment(Payment payment)
        {
            _context.Pagamentos.Add(payment);
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transacoes.Add(transaction);
        }

        public async Task<Payment> GetPaymentByOrderId(Guid pedidoId)
        {
            return await _context.Pagamentos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.OrderId == pedidoId);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByOrderId(Guid pedidoId)
        {
            return await _context.Transacoes.AsNoTracking()
                .Where(t => t.Payment.OrderId == pedidoId).ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}