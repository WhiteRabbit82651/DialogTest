package crc643f2292cdc7479c29;


public class Dialog_AlertDialogShowListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.content.DialogInterface.OnShowListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onShow:(Landroid/content/DialogInterface;)V:GetOnShow_Landroid_content_DialogInterface_Handler:Android.Content.IDialogInterfaceOnShowListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("DialogText.Android.Dialog+AlertDialogShowListener, DialogTest.Android", Dialog_AlertDialogShowListener.class, __md_methods);
	}


	public Dialog_AlertDialogShowListener ()
	{
		super ();
		if (getClass () == Dialog_AlertDialogShowListener.class)
			mono.android.TypeManager.Activate ("DialogText.Android.Dialog+AlertDialogShowListener, DialogTest.Android", "", this, new java.lang.Object[] {  });
	}


	public void onShow (android.content.DialogInterface p0)
	{
		n_onShow (p0);
	}

	private native void n_onShow (android.content.DialogInterface p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
