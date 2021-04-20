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
            var friend = new Friend();
            
            Console.Write("Для добавления друга введите его E-Mail:");
            friend.Email = Console.ReadLine();

            try
            {
                friendService.Create(friend.Email, user);
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
