<%@ Application Language="C#" %>
<script RunAt="server"> 
    void Application_Start(object sender, EventArgs e)
    {
        //// Code that runs on application startups
        Cthuvien.kenh.KENH_DNS();
        khud_files.THAM_SO_MENU();
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
        //ht_macb.PHT_LICHSU_DANGNHAP_NH();
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e)
    {
        //ht_macb.PHT_DS_USER_ONLINE_NH();
        
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        //ht_macb.PHT_DS_USER_ONLINE_NH("0");
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
</script>
