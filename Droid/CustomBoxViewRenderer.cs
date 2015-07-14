using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Android.Graphics;

// CustomBoxViewのレンダラーをCustomBoxRendererに変更する宣言
[assembly:ExportRenderer(typeof(CustomBox.CustomBoxView), typeof(CustomBox.Droid.CustomBoxViewRenderer))]
namespace CustomBox.Droid
{
	/// <summary>
	/// BoxViewに対応した、BoxViewRendererを継承したクラスをカスタムレンダラークラスとして作成
	/// </summary>
	public class CustomBoxViewRenderer : Xamarin.Forms.Platform.Android.BoxRenderer
	{
		/// <Docs>The Canvas to which the View is rendered.</Docs>
		/// <summary>
		/// BoxViewのカスタマイズはDrawで行う
		/// </summary>
		/// <param name="canvas">Canvas.</param>
		public override void Draw(Android.Graphics.Canvas canvas)
		{
			// 2重に描画してしまうので、baseは描画しない
			//base.Draw(canvas);

			// ElementをキャストしてFormsで定義したCustomBoxViewを取得
			var formsBox = (CustomBoxView)Element;

			// Androidの描画はPaintを使用
			using (var paint = new Paint()) 
			{
				// 塗りつぶし色の設定
				paint.Color = formsBox.FillColor.ToAndroid();

				// 吹き出し部分の設定
				// パスの生成
				var path = new Path();

				// スタート地点の設定
				path.MoveTo(0, 0);

				// 経由地点の設定
				path.LineTo(100, 10);
				path.LineTo(100, 100);

				// パスを繋げる
				path.Close();

				// 描画
				canvas.DrawPath(path, paint);


				// 角の丸い四角の設定
				// 角丸の直径を決める
				// widthとheightを比較して小さい方を基準にする
				var minSize = Math.Min(Width, Height);

				// 指定するのは直径なので、指定半径を2倍する
				var diameter = formsBox.Radius * 2;
				// 角丸の直径はminSize以下でなければならない
				if (diameter > minSize)
					diameter = minSize;

				// 描画領域の設定
				var rect = new RectF(0, 0, (float)Width, (float)Height);

				//四角形描画
				canvas.DrawRoundRect(rect, diameter, diameter, paint);
			}
		}
	}
}


