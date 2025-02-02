﻿using HahnBackendTestCRUD.DTOs;
using HahnBackendTestCRUD.DTOs.Ticket;
using HahnBackendTestCRUD.Helpers;
using HahnBackendTestCRUD.Models.Entities;

namespace HahnBackendTestCRUD.Interfaces
{
    public interface ITicketRepository
    {
        Task<PaginatedResult<Ticket>> GetAllAsync(QueryObject query);

        Task<Ticket?> GetByIdAsync(int id);
        Task<Ticket> CreateAsync(Ticket ticket);
        Task<Ticket?> UpdateAsync(int id, UpdateTicketRequestDto ticketDto); 
        Task<Ticket> DeleteAsync(int id);
    }
}
