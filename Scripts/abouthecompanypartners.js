//---------------------------------------------------------------------
$(document).ready(function () {
    $(".companyprofilemaindivd:not(:first)").hide();
});

    function hrefclickfunc() {
        $("#dividaboutthecompany").click(function () {

            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#aboutthecompany").slideToggle("slow")
        });
        $("#hldividaboutthecompany").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#aboutthecompany").slideToggle("slow")
        });
        /*------------2----------*/
        $("#dividcompanyprofile").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#companyprofile").slideToggle("slow")
        });
        $("#hldividcompanyprofile").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#companyprofile").slideToggle("slow")
        });
        /*------------3----------*/
        $("#dividhotsale").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#hotsale").slideToggle("slow")
        });
        $("#hldividhotsale").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#hotsale").slideToggle("slow")
        });
        /*------------4----------*/
        $("#dividfeaturedproducts").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#featuredproducts").slideToggle("slow")
        });
        $("#hldividfeaturedproducts").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#featuredproducts").slideToggle("slow")
        });
        /*------------5----------*/
        $("#dividinquiretocompany").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#inquiretocompany").slideToggle("slow")
        });
        $("#hldividinquiretocompany").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#inquiretocompany").slideToggle("slow")
        });
        /*------------6----------*/
        $("#dividmaplocation").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#maplocation").slideToggle("slow")
        });
        $("#hldividmaplocation").click(function () {
            $(".companyprofilemaindivd:visible").slideUp("slow");
            $("#maplocation").slideToggle("slow")
        });
    }


    function hrefloadfunc() {

        var lochash = window.location.hash;

        switch (lochash) {
            case ("#aboutthecompany"):
                $(".companyprofilemaindivd:visible").slideUp("slow");
                $("#aboutthecompany").slideToggle("slow")
                break;
            case ("#companyprofile"):
                $(".companyprofilemaindivd:visible").slideUp("slow");
                $("#companyprofile").slideToggle("slow")
                break;
            case ("#hotsale"):
                $(".companyprofilemaindivd:visible").slideUp("slow");
                $("#hotsale").slideToggle("slow")
                break;
            case ("#featuredproducts"):
                $(".companyprofilemaindivd:visible").slideUp("slow");
                $("#featuredproducts").slideToggle("slow")
                break;
            case ("#inquiretocompany"):
                $(".companyprofilemaindivd:visible").slideUp("slow");
                $("#inquiretocompany").slideToggle("slow")
                break;
            case ("#maplocation"):
                $(".companyprofilemaindivd:visible").slideUp("slow");
                $("#maplocation").slideToggle("slow")
                break;
        }
    }






//---------------------------------------------------------------------
         