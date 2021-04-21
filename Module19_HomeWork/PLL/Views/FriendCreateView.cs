using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendCreateView
    {

        FriendService friendService;
        public FriendCreateView(FriendService friendService)
        {
            this.friendService = friendService;
        }
        public void Show(User user)
        {
            string friendEmail;

            Console.Write("Для добавления друга введите его E-Mail: ");
            friendEmail = Console.ReadLine();

            try
            {
                var newFriend = friendService.Create(friendEmail, user);
                SuccessMessage.Show($"Новый друг {newFriend.FirstName} {newFriend.LastName} успешно добавлен:");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с таким E-Mail не существует.");
            }
            catch (WrongFriendException)
            {
                AlertMessage.Show("Нельзя добавить в друзья самого себя.");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга.");
            }

        }

    }
}
