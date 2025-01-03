# Generic forms with WinForms designer for .NET8

This repository shows how to use generic controls with WinForms designer. The designer does not support generics out of the box, so a lot of workarounds are necessary. 

I mainly focus on .NET 8, but most of the workarounds are also necessary for .NET Framework projects.

At the time of writing this, the current Visual Studio 2022 version is 17.11, but the designer behavior might change in the future.


## Simple sample: generic form


The sample [GenericForm](/GenericForm) consists of a simple form with a generic declaration:

~~~~c#
  public partial class FormGeneric<TClass> : Form
    where TClass : BaseClass
  {
~~~~


When opening this form in designer, this error is reported:
![Designer error](images/designer_error1.png)


~~~~
The designer could not be shown for this file because none of the classes within it can be designed. 

  at Microsoft.DotNet.DesignTools.Client.CodeDom.CodeDomManager.d__13.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.CodeDom.CodeDomManager.<>c__DisplayClass12_0.<b__0>d.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.VisualStudio.Threading.ReentrantSemaphore.NotAllowedSemaphore.<>c__DisplayClass2_0.<b__0>d.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.VisualStudio.Threading.ReentrantSemaphore.NotAllowedSemaphore.d__2.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.CodeDom.CodeDomManager.d__12.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.Loader.VsDesignerLoader.d__58.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.Loader.VsDesignerLoader.<>c__DisplayClass56_0.<b__1>d.MoveNext()  

~~~~


To open the "FormGeneric" in my sample, two steps are necessary:

* Step 1: In the main form file, replace this:

  ~~~~c#
    public partial class FormGeneric<TClass> : Form
      where TClass : BaseClass
  ~~~~

  with this:

  ~~~~c#
    public partial class FormGeneric : Form
  ~~~~

* Step 2: In the ".Designer.cs" file, replace

  ~~~~c#
    partial class FormGeneric<TClass>
  ~~~~

  with this:

  ~~~~c#
    partial class FormGeneric
  ~~~~


Of course, my sample project will not compile after this change, because I use the generic parameter in some code. Ignore the compilation error and open the form in designer - it should work.



## Simple sample: generic form with "resx.file"
This sample [GenericFormWithResx](/GenericFormWithResx) adds a PictureBox to the form, which displays an image from a local resource file. 
This file is written to "FormGeneric.resx".

After having removed the generics workarouns from the previous sample, the "InitializeComponent" code will not compile because of this line:

~~~~c#
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric));
~~~~

So, add the generics declaration here, too:
~~~~c#
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric<TClass>));
~~~~

When launching the sample, there will be an exception:

~~~~c#
System.Resources.MissingManifestResourceException
  HResult=0x80131532
  Message=Could not find the resource "GenericFormWithResx.FormGeneric`1.resources" among the resources "GenericFormWithResx.FormGeneric.resources", "GenericFormWithResx.Properties.Resources.resources" embedded in the assembly "GenericFormWithResx", nor among the resources in any satellite assemblies for the specified culture. Perhaps the resources were embedded with an incorrect name.
  Source=System.Private.CoreLib
  StackTrace:
   at System.Resources.ManifestBasedResourceGroveler.HandleResourceStreamMissing(String fileName)
   at System.Resources.ManifestBasedResourceGroveler.GrovelForResourceSet(CultureInfo culture, Dictionary`2 localResourceSets, Boolean tryParents, Boolean createIfNotExists)
   at System.Resources.ResourceManager.InternalGetResourceSet(CultureInfo culture, Boolean createIfNotExists, Boolean tryParents)
   at System.Resources.ResourceManager.GetObject(String name, CultureInfo culture, Boolean wrapUnmanagedMemStream)
   at GenericFormWithResx.FormGeneric`1.InitializeComponent() in E:\Projekte\Temp\GenericFormWithResx\FormGeneric.Designer.cs:line 58
   at GenericFormWithResx.FormGeneric`1..ctor() in E:\Projekte\Temp\GenericFormWithResx\FormGeneric.cs:line 9
   at GenericFormWithResx.Program.Main() in E:\Projekte\Temp\GenericFormWithResx\Program.cs:line 15
~~~~

As you can see, .NET tries to load a file "FormGeneric\`1.resources", while the designer resx file is compiled to "FormGeneric.resources".
The backtick char (or grave accent) followed by a number stands for "generic class with n type arguments". If the class had three type parameters, .NET would look for "FormGeneric\`3.resources".

So, duplicate the file "FormGeneric.resx" and name it "FormGeneric\`1.resx". The result should look like this:

![FormGeneric`1.resx](images/generic_resx.png)

Whenever you make changes to "FormGeneric.resx", you will have to copy the content of this file to "FormGeneric\`1.resx".


To sum it up: In order to open this form in designer, we need three changes:


* Step 1: In the main form file, replace this:

  ~~~~c#
    public partial class FormGeneric<TClass> : Form
      where TClass : BaseClass
  ~~~~

  with this:

  ~~~~c#
    public partial class FormGeneric : Form
  ~~~~

* Step 2: In the ".Designer.cs" file, replace

  ~~~~c#
    partial class FormGeneric<TClass>
  ~~~~

  with this:

  ~~~~c#
    partial class FormGeneric
  ~~~~

* Step 3: In "InitializeComponent" of the ".Designer.cs" file, replace

  ~~~~c#
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric<TClass>));
  ~~~~

  with this:
  ~~~~c#
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric));
  ~~~~

When opening the designer, another error will be reported:

~~~~
Value cannot be null. (Parameter 'baseName')    
 
  at StreamJsonRpc.JsonRpc.d__154`1.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.Host.ServerHost.d__16.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.DesignToolsClientLoader.d__29.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.DesignToolsClientLoader.<>c__DisplayClass25_1.<<-ctor>b__1>d.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.DesignToolsClientLoader.d__27.MoveNext()  

~~~~

![Designer error with resx](images/designer_error2.png)

Note: I first observed this error after migrating to .NET6, so it might not happen in .NET Framework projects.


There is a workaround:
* Step 1: rename the file "FormGeneric\`1.resx" so that the filename does not contain any backtick.
You will have to repeat this for all files with a backtick in the file name in the current project.
* Step 2: if you have seen the error, you must close Visual Studio and reopen it. Otherwise, the same error will be shown even after 
applying the workaround. If you applied the workaround before the error was reported, you can open the designer safely.

Of course, you have to rename the resx files again to the backtick version before launching your application, otherwise resources will not be found.

## Inheritance from generic form
The next sample [GenericFormSubclass](/GenericFormSubclass) adds a subclass to the generic form.
The base class is in a class library project "GenericFormLib", the sub class in "GenericFormApp". I did this to concentrate on the subclass problem - 
further problems might arise if the generic base class and the sub class are inside the same project.

When opening the child class "FormChild" in designer, this error is shown:

~~~~
Cannot create an instance of GenericFormLib.FormGeneric`1[TClass] because Type.ContainsGenericParameters is true. 

  at System.Reflection.RuntimeConstructorInfo.CheckCanCreateInstance(Type declaringType, Boolean isVarArg)
  at System.Reflection.RuntimeConstructorInfo.ThrowNoInvokeException()
  at System.Reflection.RuntimeConstructorInfo.Invoke(BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
  at System.Reflection.ConstructorInfo.Invoke(Object[] parameters)
  at System.ComponentModel.ReflectTypeDescriptionProvider.CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, Object[] args)
  at System.ComponentModel.TypeDescriptor.CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, Object[] args)
  at Microsoft.DotNet.DesignTools.Host.RemoteDesignerHost.CreateInstance(Type type)
  at Microsoft.DotNet.DesignTools.Host.RemoteDesignerHost.CreateComponent(Type componentClass, String name)
  at Microsoft.DotNet.DesignTools.Serialization.DesignerSerializationManager.CreateInstance(Type type, ICollection arguments, String name, Boolean addToContainer)
  at Microsoft.DotNet.DesignTools.Serialization.DesignerSerializationManager.System.ComponentModel.Design.Serialization.IDesignerSerializationManager.CreateInstance(Type type, ICollection arguments, String name, Boolean addToContainer)
  at Microsoft.DotNet.DesignTools.Serialization.TypeCodeDomSerializer.Deserialize(IDesignerSerializationManager manager, CodeTypeDeclaration declaration)
  at Microsoft.DotNet.DesignTools.Sessions.Session.DeserializeToRootComponent(CodeTypeDeclaration typeDeclaration, String rootComponentClassName)
  at Microsoft.DotNet.DesignTools.Sessions.Session.DeserializeRootComponent(CodeTypeDeclaration typeDeclaration, String rootComponentClassName, ResourceContentData[] resourceDocDataContent, String basePath)
  at Microsoft.DotNet.DesignTools.Protocol.Endpoints.Sessions.InitializeRootComponentHandler.HandleRequest(InitializeRootComponentRequest request)
  at Microsoft.DotNet.DesignTools.Protocol.Endpoints.RequestHandler`2.Microsoft.DotNet.DesignTools.Protocol.Endpoints.IRequestHandler.HandleRequest(Request request) 

~~~~

![Designer error with subclass](images/designer_error3.png)

Explanation: the designer tries to create the base class and cannot do so because it cannot infer the generic type parameters.

Workaround: we break the inheritance hierarchy and introduce a base class which resides between "FormChild" and "FormGeneric<TClass>":

~~~~c#
  public class FormGenericWrapper : FormGeneric<ChildClass>
  {

  }
~~~~

Now, we can let "FormChild" inherit from this base class:

~~~~c#
  public partial class FormChild : FormGenericWrapper
  {
~~~~

Some time ago, it worked to place this wrapper class inside the main form file, but some Visual Studio 2022 version changed this, now this error is reported:

~~~~
The class FormGenericWrapper can be designed, but is not the first class in the file. 
Visual Studio requires that designers use the first class in the file. 
Move the class code so that it is the first class in the file and try loading the designer again. 

  at Microsoft.DotNet.DesignTools.Client.CodeDom.CodeDomManager.d__13.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.CodeDom.CodeDomManager.<>c__DisplayClass12_0.<b__0>d.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.VisualStudio.Threading.ReentrantSemaphore.NotAllowedSemaphore.<>c__DisplayClass2_0.<b__0>d.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.VisualStudio.Threading.ReentrantSemaphore.NotAllowedSemaphore.d__2.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.CodeDom.CodeDomManager.d__12.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.Loader.VsDesignerLoader.d__58.MoveNext()
  --- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.DotNet.DesignTools.Client.Loader.VsDesignerLoader.<>c__DisplayClass56_0.<b__1>d.MoveNext() 
~~~~

![Designer error: wrapper in same file](images/designer_error_wrapper_same_file.png)


So, add a new file to the project, containing only this wrapper:

![Generic form wrapper](images/generic_wrapper.png)


After having designed your form, you could remove the wrapper again. Or you keep it - the workaround might be necessary again later.


## Inheritance from generic form (single project)
The previous sample had separated the generic base form and the non generic child form in two projects. I did this with reason, because it will cause big problems if 
you place base class and child class in the same project and the base class method `InitializeComponent` also uses a `ComponentResourceManager` and thus loads data from a resx file.

In the sample [GenericFormSubclassResx](/GenericFormSubclassResx), the base class `FormGeneric.cs` contains a picture box, and thus a file "FormGeneric\`1.resx" exists, which contains the image.

To open the child form `FormChilds.cs` we start with the workarounds we know:

* Step 1: Rename resx files with backtick
* Step 2: add the wrapper:
  ~~~~c#
  public class FormGenericWrapper : FormGeneric<ChildClass>
  {
  ~~~~

The app will fail to start, because it cannot load the resources. Thats fine.

But wait - the designer for `FormChild` also reports the same error that happens at runtime:
![Designer error: could not find the resource...](images/designer_error4.png)

The reason is clear: the designer instantiates the parent file, and its `InitializeComponent` contains the code to load the resources from class `FormGeneric<TClass>`.
So we would have to get rid of this piece of code. 


Note: sometimes, the designer does not seem to reload changes to the base class. You might have to restart Visual Studio.

### Simple workaround

The simplest way could be to just comment all usages of the `resources` variable:

~~~~c#
      //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric<TClass>));
      ...
      // 
      // pictureBox
      // 
      //this.pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
      this.pictureBox.Location = new Point(192, 288);
~~~~

Here, the `PictureBox` in the subclass will be empty, which is not really a problem in my sample. But you might have other apps where
the resx content of the base class matters for subclasses.


### Complex workaround

We will try to get rid of the generics declarations. Unfortunately, the assembly of the project must be compiled so that the designer can load the base class.
This means that no compilation errors are allowed. 


So we apply all steps we already know:

* Step 1: Rename resx files with backtick
* Step 2: In the file `FormGeneric.cs` of the base class, remove the generic declaration:
  ~~~~c#
    //public partial class FormGeneric<TClass> : Form
    //  where TClass : BaseClass
    public partial class FormGeneric : Form
  ~~~~
* Step 3: in `FormGeneric.Designer.cs`, make two changes:
  ~~~~c#
    //partial class FormGeneric<TClass>
    partial class FormGeneric
  ~~~~

  and

  ~~~~c#
        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric<TClass>));
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric));
  ~~~~
* Step 4: the child form inherits from the now non generic form:

  ~~~~c#
    public class FormChild : FormGeneric
    //public class FormChild : FormGeneric<ChildClass>
  ~~~~
  
  We don't need a wrapper here, as we removed the generic stuff.
* Step 5: fix all compilation errors. My example has a method `FormGeneric.SetItem(TClass item)`. As we removed the generic parameter "TClass" of the class, 
  we could remove the method itself. This means we have to fix all calling code in the project, too.
  
  In my sample, it works to add the generic type parameter to `SetItem`:
  ~~~~c#
    public void SetItem<TClass>(TClass item) where TClass : BaseClass
    //public void SetItem(TClass item)
    {
      this.textBoxItem.Text = item.ToString();
    }
  ~~~~

The last step might mean a lot of effort, and this might be the point where it is better to give up generic WinForms controls ;-).




## Generic control
I was more than surprised to see that it is possible to use generic controls in other forms.

In the sample [GenericControl](/GenericControl), I defined a generic combobox like this:

~~~~c#
  public partial class ComboBoxGeneric<TItem> : ComboBox
    where TItem : BaseClass
  {
    public ComboBoxGeneric()
    {
      InitializeComponent();
    }

    public new TItem? SelectedItem
    {
      get
      {
        return (TItem?)base.SelectedItem;
      }
      set
      {
        base.SelectedItem = value;
      }
    }
  }
~~~~

Im my form, I first added a regular ComboBox, then modified the ".Designer.cs" code to use the generic combobox (it did not appear in the toolbox):

~~~~c#
    private void InitializeComponent()
    {
      this.comboBox = new ComboBoxGeneric<ChildClass>();
      ...
    }

    private ComboBoxGeneric<ChildClass> comboBox;
~~~~

Whow, the designer still loads! That was easy.


But if you want to open the "ComboBoxGeneric" in designer, you have to apply the workarounds from my first sample. 
