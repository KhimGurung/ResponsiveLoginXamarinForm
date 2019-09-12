# ResponsiveLoginXamarinForm
Making page responsive in xamarin form is not that difficult. Detecting device and its orientation is the inital part and applying the changes for responsiveness is done from the code behind. A simple registration form is given here and screenshot of both landscape and potrait is given here in both android phone and tablet.


For detecting device orientation, a seperate class is made with name <b>BaseOrientationPage</b> given below.

```c#

public class BaseOrientationPage : ContentPage
    {
        protected enum OrientationValue
        {
            Portrait,
            Landscape
        }

        private double _oldWidth, _oldHeight;

        protected virtual void OrientationChanged(OrientationValue newOrientation) { }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if(width != _oldWidth || height != _oldHeight)
            {
                _oldHeight = height;
                _oldWidth = width;

                OrientationChanged(width > height ? OrientationValue.Landscape : OrientationValue.Portrait);
            }
        }
    }

```
<hr>

# xaml 

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<Page:BaseOrientationPage xmlns="http://xamarin.com/schemas/2014/forms"
                          xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                          xmlns:d="http://xamarin.com/schemas/2014/forms/design"
                          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                          xmlns:skia="clr-namespace:SkiaSharp.Views.Forms;assembly=SkiaSharp.Views.Forms"
                          xmlns:enhancedEntry="clr-namespace:LeoJHarris.FormsPlugin.Abstractions;assembly=LeoJHarris.FormsPlugin.Abstractions"
                          xmlns:Page="clr-namespace:ResponsiveRegistrationForm"
                          mc:Ignorable="d"
                          x:Class="LoginPageDesign.MainPage">
    <AbsoluteLayout BackgroundColor="#ffffff">
        <skia:SKCanvasView PaintSurface="SKCanvasView_PaintSurface"
                           AbsoluteLayout.LayoutFlags="All"
                           AbsoluteLayout.LayoutBounds="0,0,1,1"/>
        <FlexLayout x:Name="PageLayout" 
                    AbsoluteLayout.LayoutFlags="All"
                    AbsoluteLayout.LayoutBounds="0,0,1,1">
            <FlexLayout x:Name="CompanyInfo"
                        Direction="Column">
                <StackLayout x:Name="LogoSection">
                    <StackLayout x:Name="LogoSectionInner">
                        <Image x:Name="Logo" 
                               Source="logo.png"/>
                        <Label x:Name="AppInfo" 
                               Text="The POS system is designed in a way that ensures the speed of 
                                     performance and the ease of full handling and this is."
                               FontSize="15"
                               TextColor="#ffffff"/>
                    </StackLayout>
                </StackLayout>
                <AbsoluteLayout x:Name="AppInfoImage" 
                                FlexLayout.Basis="65%">
                    <skia:SKCanvasView x:Name="Center" 
                                   PaintSurface="SKCanvasView_PaintSurface_2"
                                   AbsoluteLayout.LayoutFlags="All"
                                   AbsoluteLayout.LayoutBounds="0,0,1,1"/>
                    <skia:SKCanvasView x:Name="Right" 
                                   PaintSurface="SKCanvasView_PaintSurface_2"
                                   AbsoluteLayout.LayoutFlags="All"
                                   AbsoluteLayout.LayoutBounds="0,0,1,1">
                    </skia:SKCanvasView>
                    <skia:SKCanvasView x:Name="Left" 
                                   PaintSurface="SKCanvasView_PaintSurface_2"
                                   AbsoluteLayout.LayoutFlags="All"
                                   AbsoluteLayout.LayoutBounds="0,0,1,1"/>
                    <skia:SKCanvasView x:Name="Top" 
                                   PaintSurface="SKCanvasView_PaintSurface_2"
                                   AbsoluteLayout.LayoutFlags="All"
                                   AbsoluteLayout.LayoutBounds="0,0,1,1"/>
                    <skia:SKCanvasView x:Name="Bottom" 
                                   PaintSurface="SKCanvasView_PaintSurface_2"
                                   AbsoluteLayout.LayoutFlags="All"
                                   AbsoluteLayout.LayoutBounds="0,0,1,1"/>
                </AbsoluteLayout>
            </FlexLayout>
            <StackLayout x:Name="LoginForm"
                         VerticalOptions="FillAndExpand">
                <Frame x:Name="LoginFormFrame" 
                       VerticalOptions="CenterAndExpand"
                       CornerRadius="20">
                    <StackLayout>
                        <Label x:Name="FormTitle" 
                               Text="Login as admin user"
                               FontAttributes="Bold"
                               TextColor="#1c1c1c"/>
                        <enhancedEntry:EnhancedEntry x:Name="Username" 
                                                     Placeholder="Username or email"
                                                     CornerRadius="25"
                                                     BorderColor="#dadada"
                                                     BorderWidth="2"
                                                     LeftIcon="user"/>
                        <enhancedEntry:EnhancedEntry x:Name="Password" 
                                                     Placeholder="Password"
                                                     CornerRadius="25"
                                                     BorderColor="#dadada"
                                                     IsPassword="True"
                                                     BorderWidth="2"
                                                     LeftIcon="lock"/>
                        <Label Text="Forget the password"
                               TextColor="#acacac"
                               FontSize="15"/>
                        <Grid x:Name="LoginButton" 
                              Margin="0,30,0,0">
                            <Grid.RowDefinitions>
                                <RowDefinition />
                            </Grid.RowDefinitions>
                            <Frame Padding="0"
                                   HasShadow="False"
                                   CornerRadius="25"
                                   IsClippedToBounds="True"
                                   Grid.Row="0">
                                <skia:SKCanvasView VerticalOptions="FillAndExpand"
                                                   HorizontalOptions="FillAndExpand"
                                                   PaintSurface="SKCanvasView_PaintSurface_1"/>
                            </Frame>
                            <Button Text="Login"
                                    TextColor="#ffffff"
                                    BackgroundColor="Transparent"
                                    CornerRadius="25"
                                    Grid.Row="0"/>
                        </Grid>
                        <Label>
                            <Label.FormattedText>
                                <FormattedString>
                                    <Span Text="Don't have account yet?"
                                          TextColor="#acacac"
                                          FontSize="15" />
                                    <Span Text=" Sign in" 
                                          TextColor="#511694"
                                          FontSize="15"/>
                                </FormattedString>
                            </Label.FormattedText>
                        </Label>
                    </StackLayout>
                </Frame>
            </StackLayout>
        </FlexLayout>
    </AbsoluteLayout>

</Page:BaseOrientationPage>

```

## Code behind that gives responsive behaviour

<b>OrientationChanged()</b> method is from <b>BaseOrientationPage</b> class. We dont need to show the inheritance here because we have xaml page of <b>page:BaseOrientationPage</b>, so it is excessable here.

```c#
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
        
        //this function is called from xaml file
        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {

            if (Device.Idiom == TargetIdiom.Tablet)
                TabletView(args, deviceOrientation);
            else
                MobileView(args, deviceOrientation);

        }
        
        //Please find rest code in the project itself, it is just for general info
     }
```

# Used Plugins

* SkiaSharp (used to get gradiant, dotted circles and curves)
* LeoJHarris.XForms.Plugins.EnhancedEntry (For advanced entry control)

# Output screenshot of both mobile and tablet in android device
<table>
  <tr>
    <td>Mobile Portrait View</td>
    <td>Mobile Landscape View</td>
  </tr>
  <tr>
    <td>
        <img src="/ResponsiveLoginXamarinForm/LoginPageDesign/images/MobilePortrait.PNG" width=300 />
    </td>
    <td>
         <img src="/ResponsiveLoginXamarinForm/LoginPageDesign/images/MobileLandScape.PNG" width=500 />
    </td>
  </tr>
    <tr>
    <td>Tablet Portrait View</td>
    <td>Tablet LandScape View</td>
  </tr>
  <tr>
    <td>
       <img src="/ResponsiveLoginXamarinForm/LoginPageDesign/images/TabletPortrait.PNG" width=300 />
    </td>
    <td>
      <img src="/ResponsiveLoginXamarinForm/LoginPageDesign/images/TabletLandScape.PNG" width=500 />
    </td>
  </tr>
</table>
