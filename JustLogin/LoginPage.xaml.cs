﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JustLogin
{
    public partial class LoginPage : ContentPage
    {
		public LoginPage()
		{
			InitializeComponent();
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignUpPage());
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			var user = new User
			{
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			};

			var isValid = AreCredentialsCorrect(user);
			if (isValid)
			{
				App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new Home(), this);
				await Navigation.PopAsync();
			}
			else
			{
				messageLabel.Text = "Login failed";
				passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect(User user)
		{
            return user.Username == ConstantValues.Username && user.Password == ConstantValues.Password;
		}
    }
}
