﻿using Lexicon.Data.Context;
using Lexicon.Data.DTO;
using Lexicon.Data.Models;

namespace Lexicon.Services.Interfaces
{
    public interface IClient
    {
        List<ClientDto> GetClients();
        ClientDto GetClient(int id);
        int AddClient(ClientDto client);
        int UpdateClient(int id, ClientDto updatedClient);
        int DeleteClient(int id);
    }
    public class ClientService : IClient
    {
        private LexiconDbContext _context;
        public ClientService(LexiconDbContext newContext)
        {
            _context = newContext;
        }
        public List<ClientDto> GetClients()
        {
            List<ClientDto> clients = (from c in _context.Clients
                                        select new ClientDto()
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            Age = c.Age,
                                            Gender = c.Gender,
                                            Email = c.Email,
                                            Phone = c.Phone
                                        }).ToList();
            return clients;
        }
        public ClientDto GetClient(int id)
        {
            ClientDto client = (from c in _context.Clients where c.Id == id
                                select new ClientDto()
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Age = c.Age,
                                    Gender = c.Gender,
                                    Email = c.Email,
                                    Phone = c.Phone
                                }).FirstOrDefault();
            return client;
        }
        public int AddClient(ClientDto client)
        {
                Client newClient = new Client();
                {
                    newClient.Name = client.Name;
                    newClient.Age = client.Age;
                    newClient.Gender = client.Gender;
                    newClient.Email = client.Email;
                    newClient.Phone = client.Phone;
                }
                _context.Clients.Add(newClient);
                _context.SaveChanges();
                return newClient.Id;
        }
        public int UpdateClient(int id, ClientDto updatedClient)
        {
            Client client = _context.Clients.FirstOrDefault(c => c.Id == id);

            if (client != null)
            {
                client.Name = updatedClient.Name;
                client.Age = updatedClient.Age;
                client.Gender = updatedClient.Gender;
                client.Email = updatedClient.Email;
                client.Phone = updatedClient.Phone;
                _context.SaveChanges();
                return client.Id;
            }
            else
                return 0;
        }
        public int DeleteClient(int id)
        {
            Client client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
                return client.Id;
            }
            else
                return 0;
        }
    }
}
