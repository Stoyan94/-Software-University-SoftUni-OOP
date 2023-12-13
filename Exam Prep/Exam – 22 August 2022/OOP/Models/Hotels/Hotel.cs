﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    
    public class Hotel : IHotel
    {
        private  IRepository<IRoom> roomslRepository;
        private  IRepository<IBooking> bookingRepository;

        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;

            roomslRepository = new RoomRepository();
            bookingRepository = new BookingRepository();
        }

        public string FullName
        {
            get => fullName; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                fullName = value;
            }
        }


        public int Category
        {
            get => category; 
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                category = value;
            }
        }

        public double Turnover => bookingRepository.All().Sum(r=> r.ResidenceDuration) * roomslRepository.All().Sum(p => p.PricePerNight);

        public IRepository<IRoom> Rooms => roomslRepository;

        public IRepository<IBooking> Bookings => bookingRepository;
    }
}
