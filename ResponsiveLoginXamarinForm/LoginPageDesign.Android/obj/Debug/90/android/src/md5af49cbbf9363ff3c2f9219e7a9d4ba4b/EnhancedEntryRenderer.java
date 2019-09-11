package md5af49cbbf9363ff3c2f9219e7a9d4ba4b;


public class EnhancedEntryRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("LeoJHarris.FormsPlugin.Droid.EnhancedEntryRenderer, LeoJHarris.FormsPlugin.Droid", EnhancedEntryRenderer.class, __md_methods);
	}


	public EnhancedEntryRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == EnhancedEntryRenderer.class)
			mono.android.TypeManager.Activate ("LeoJHarris.FormsPlugin.Droid.EnhancedEntryRenderer, LeoJHarris.FormsPlugin.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public EnhancedEntryRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == EnhancedEntryRenderer.class)
			mono.android.TypeManager.Activate ("LeoJHarris.FormsPlugin.Droid.EnhancedEntryRenderer, LeoJHarris.FormsPlugin.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public EnhancedEntryRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == EnhancedEntryRenderer.class)
			mono.android.TypeManager.Activate ("LeoJHarris.FormsPlugin.Droid.EnhancedEntryRenderer, LeoJHarris.FormsPlugin.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
