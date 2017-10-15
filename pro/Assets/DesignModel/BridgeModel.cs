using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IShap
{
    public string name;
    public IRenderEngine renderEngine;
    public IShap(IRenderEngine renderEngine)
    {
        this.renderEngine = renderEngine;
    }
    public void Draw()
    {
        renderEngine.Render(name);
    }
}

public abstract class IRenderEngine
{
    public abstract void Render(string name);
}
public class Sphere:IShap
{

    public Sphere(IRenderEngine re) : base(re)
    {
        name = "Sphere";
    }
    //public string name = "Sphere";
    //public OpenGL openGL = new OpenGL();
    //public DirectX dx = new DirectX();
    //public void Draw()
    //{
    //    openGL.Render(name);
    //}

    //public void DrawDX()
    //{
    //    dx.Render(name);
    //}

}

public class Cube:IShap
{

    public Cube(IRenderEngine re) : base(re)
    {
        name = "Cube";
    }
    //public string name = "Cube";
    //public OpenGL openGL = new OpenGL();
    //public DirectX dx = new DirectX();
    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawDX()
    //{
    //    dx.Render(name);
    //}
}

public class Capsule:IShap
{
    public Capsule(IRenderEngine re):base(re)
    {
        name = "Capsule";
    }
    //public string name = "Capsule";
    //public OpenGL openGL = new OpenGL();
    //public DirectX dx = new DirectX();
    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawDX()
    //{
    //    dx.Render(name);
    //}
}

public class OpenGL:IRenderEngine
{

    public override void Render(string name)
    {
        Debug.LogWarning("OpenGL绘制出" + name);
    }
}

public class DirectX:IRenderEngine
{

    public override void Render(string name)
    {
        Debug.LogWarning("DirectX绘制出" + name);
    }
}

public class BridgeModel : MonoBehaviour {

	// Use this for initialization
	void Start () {

        IRenderEngine renderEngine = new DirectX();
        Sphere sphere = new Sphere(renderEngine);
        sphere.Draw();
        Cube cube = new Cube(renderEngine);
        cube.Draw();
        Capsule capsule = new Capsule(renderEngine);
        capsule.Draw();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
