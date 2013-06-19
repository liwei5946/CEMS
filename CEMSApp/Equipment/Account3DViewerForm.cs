using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using System.Windows.Media;
using System.IO;

namespace CEMSApp.Equipment
{
    public partial class Account3DViewerForm : ChildForm
    {
        WpfObjViewer.MainWindow _WpfObjViewer = null;
        public Account3DViewerForm(byte[] ObjModel)
        {
            InitializeComponent();
            /*
            //HelixToolkit.Wpf.HelixVisual3D hv3d = new HelixToolkit.Wpf.HelixVisual3D();
            //ObjReader objReader = new ObjReader();
            //Model3DGroup group = objReader.Read("3d.obj");
            //AnaglyphView3D anv3d = new AnaglyphView3D();
            //GeometryModel3D _objRead = (GeometryModel3D)group.Children[0];
            //System.Windows.Controls.Button btn = new System.Windows.Controls.Button();
            //btn.Content = "Button in WPF";
            //Model3D model = (Model3D)group.Children[0];
            //elementHost1.Child = anv3d;

            // Create a model group
            var modelGroup = new Model3DGroup();

            // Create a mesh builder and add a box to it
            var meshBuilder = new MeshBuilder(false, false);
            meshBuilder.AddBox(new Point3D(0, 0, 1), 1, 2, 0.5);
            meshBuilder.AddBox(new Rect3D(0, 0, 1.2, 0.5, 1, 0.4));

            // Create a mesh from the builder (and freeze it)
            var mesh = meshBuilder.ToMesh(true);

            // Create some materials
            var greenMaterial = MaterialHelper.CreateMaterial(Colors.Green);
            var redMaterial = MaterialHelper.CreateMaterial(Colors.Red);
            var blueMaterial = MaterialHelper.CreateMaterial(Colors.Blue);
            var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);

            // Add 3 models to the group (using the same mesh, that's why we had to freeze it)
            modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Material = greenMaterial, BackMaterial = insideMaterial });
            modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(-2, 0, 0), Material = redMaterial, BackMaterial = insideMaterial });
            modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(2, 0, 0), Material = blueMaterial, BackMaterial = insideMaterial });
            // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
            this.Model = modelGroup;
            HelixViewport3D hv3d = new HelixViewport3D();
            //hv3d.ContainerFromElement(elementHost1.Child);
             * */
            elementHost1.Dock = DockStyle.Fill;
            //MessageBox.Show(testStr);
            
            try
            {
                if (ObjModel != null)
                {
                    MemoryStream ms = new MemoryStream(ObjModel);
                    _WpfObjViewer = new WpfObjViewer.MainWindow(ms);
                    //_WpfObjViewer.testStr = "hello world!";
                    elementHost1.Child = _WpfObjViewer;
                }
                else
                {
                    Console.WriteLine("ObjModel is NULL!!!");
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public string Model { get; set; }
        //public byte[] ObjModel { get; set; }
    }
}
