
using ResponsiveRegistrationForm;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.ComponentModel;
using Xamarin.Forms;

namespace LoginPageDesign
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        OrientationValue deviceOrientation;
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override void OrientationChanged(OrientationValue newOrientation)
        {
            base.OrientationChanged(newOrientation);
            deviceOrientation = newOrientation;
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            
            if(deviceOrientation == OrientationValue.Landscape)
                LandScapeView(args);
            else
                PortraitView(args);

        }

        private void LandScapeView(SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * 0.57f, 0);

                path.CubicTo(info.Width * 0.54f, info.Height * 0.14f,
                             info.Width * 0.46f, info.Height * 0.24f,
                             info.Width * 0.46f, info.Height * 0.45f);
                path.CubicTo(info.Width * 0.46f, info.Height * 0.68f,
                             info.Width * 0.57f, info.Height * 0.83f,
                             info.Width * 0.6f, info.Height);
                path.LineTo(0, info.Height);
                path.Close();


                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    paint.Style = SKPaintStyle.Fill;
                    paint.Color = SKColor.Parse("#9b1d75");

                    paint.Shader = SKShader.CreateLinearGradient(
                                            new SKPoint(info.Width * 0.6f, info.Height),
                                            new SKPoint(0, 0),
                                            new SKColor[] { Color.FromHex("#511694").ToSKColor(), Color.FromHex("#9b1d75").ToSKColor() },
                                            new float[] { 0.18f, 1 },
                                            SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }
            }

            PageLayout.Direction = FlexDirection.Row;
            
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                LoginFormFrame.HasShadow = false;
                LoginFormFrame.Margin = new Thickness(60, 0);
                LoginFormFrame.Padding = new Thickness(0);

                FlexLayout.SetBasis(CompanyInfo, new FlexBasis(0.55f, true));
                FlexLayout.SetBasis(LoginForm, new FlexBasis(0.45f, true));
            }
            else
            {
                FormTitle.FontSize = 25;

                Username.Margin = new Thickness(0, 15, 0, 0);
                Password.Margin = new Thickness(0, 15, 0, 0);
                LoginButton.Margin = new Thickness(0, 15, 0, 0);

                LoginFormFrame.HasShadow = true;
                LoginFormFrame.Margin = new Thickness(0,30,70,30);
                LoginFormFrame.Padding = new Thickness(20);

                FlexLayout.SetBasis(CompanyInfo, new FlexBasis(0.35f, true));
                FlexLayout.SetBasis(LoginForm, new FlexBasis(0.65f, true));
            }
        }

        private void PortraitView(SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(0, info.Height * 0.57f);

                path.CubicTo(info.Width * 0.14f, info.Height * 0.54f,
                             info.Width * 0.24f, info.Height * 0.46f,
                             info.Width * 0.45f, info.Height * 0.46f);
                path.CubicTo(info.Width * 0.68f, info.Height * 0.46f,
                             info.Width * 0.83f, info.Height * 0.57f,
                             info.Width, info.Height * 0.6f);
                path.LineTo(info.Width, 0);
                path.Close();


                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    paint.Style = SKPaintStyle.Fill;
                    paint.Color = SKColor.Parse("#9b1d75");

                    paint.Shader = SKShader.CreateLinearGradient(
                                            new SKPoint(0, info.Height * 0.54f),
                                            new SKPoint(info.Width, 0),
                                            new SKColor[] { Color.FromHex("#511694").ToSKColor(), Color.FromHex("#9b1d75").ToSKColor() },
                                            new float[] { 0.18f, 1 },
                                            SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }
            }

            PageLayout.Direction = FlexDirection.Column;
            LoginFormFrame.HasShadow = true;

            if(Device.Idiom == TargetIdiom.Tablet)
            {
                LoginFormFrame.Padding = new Thickness(30, 40);
                LoginFormFrame.Margin = new Thickness(80, 0);
            }
            else
            {
                FormTitle.FontSize = 25;

                Username.Margin = new Thickness(0, 25, 0, 0);
                Password.Margin = new Thickness(0, 20, 0, 0);
                LoginButton.Margin = new Thickness(0, 25, 0, 0);

                LoginFormFrame.Padding = new Thickness(20,40);
                LoginFormFrame.Margin = new Thickness(30, 0);
            }
            

            FlexLayout.SetBasis(CompanyInfo, new FlexBasis(0.2f, true));
            FlexLayout.SetBasis(LoginForm, new FlexBasis(0.8f, true));
        }

        private void SKCanvasView_PaintSurface_1(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                SKRect rect = new SKRect(0, 0, info.Width, info.Height);

                paint.Shader = SKShader.CreateLinearGradient(
                                        new SKPoint(0, info.Height / 2),
                                        new SKPoint(info.Width, info.Height / 2),
                                         new SKColor[] { Color.FromHex("#9b1d75").ToSKColor(), Color.FromHex("#511694").ToSKColor()},
                                        new float[] { 0.15f, 1 },
                                        SKShaderTileMode.Clamp);

                canvas.DrawRect(rect, paint);
            }

        }
    }
}
