﻿using PC.Context;
using PC.Service.IRepository.DiscountAndOrder;
using PC.Utility.Data;
using PD.Entity.DiscountAndOrder;

namespace PD.Repositories.DiscountAndOrder;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}