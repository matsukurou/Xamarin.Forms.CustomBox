using System;

using Xamarin.Forms;

// CustomBoxViewのレンダラーをCustomBoxRendererに変更する宣言
[assembly:ExportRenderer(typeof(CustomBox.CustomBoxView), typeof(CustomBox.iOS.CustomBoxViewRenderer))]
namespace CustomBox.iOS
{
	/// <summary>
	/// BoxViewに対応した、BoxViewRendererを継承したクラスをカスタムレンダラークラスとして作成
	/// </summary>
	public class CustomBoxViewRenderer : Xamarin.Forms.Platform.iOS.BoxRenderer
	{
	}
}


