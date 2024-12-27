using HotelManagementUG.Domain.Entities;
using HotelManagementUG.Domain.Interfaces;
using System.Net.Mail;

namespace HotelManagementUG.Application
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;


        public ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetReservationByIdAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByHotelIdAsync(int id)
        {
            return await _reservationRepository.GetReservationsByHotelIdAsync(id);
        }

        public async Task<Reservation> MakeReservationAsync(Reservation reservation)
        {
            var room = await _roomRepository.GetRoomByIdAsync(reservation.RoomId);
            if (room == null)
            {
                throw new Exception("Room not found.");
            }

            await _reservationRepository.AddReservationAsync(reservation);

            await SendEmailNotificationAsync(reservation);

            return reservation;
        }

        private async Task SendEmailNotificationAsync(Reservation reservation)
        {
            var emailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@hotel.com"),
                Subject = "Reservation Confirmation",
                Body = $"Your reservation for room {reservation.RoomId} from {reservation.CheckInDate.ToShortDateString()} to {reservation.CheckOutDate.ToShortDateString()} has been confirmed.",
                IsBodyHtml = true
            };
            emailMessage.To.Add(reservation.Guests[0].Email);

            using (var smtpClient = new SmtpClient("smtp.yourmailserver.com"))
            {
                await smtpClient.SendMailAsync(emailMessage);
            }
        }
    }
}
