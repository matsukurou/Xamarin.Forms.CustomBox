using System;

using Xamarin.Forms;

namespace CustomBox
{
	public class CustomBoxPage : ContentPage
	{
		public CustomBoxPage()
		{
			// iOSの場合は上部に空白
			Padding = new Thickness(0, Device.OnPlatform(20,0,0), 0, 0);

			this.BackgroundColor = Color.White;

			// CustomBoxViewの生成
			var customBox = new CustomBoxView(Color.Purple, 50);

			// レイアウトを生成
			var stackLayout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				// レイアウトにCustomBoxViewを追加
				Children =
				{
					customBox,
				}
			};

			// ページのコンテントにレイアウトを設定
			Content = stackLayout;
		}
	}
}


