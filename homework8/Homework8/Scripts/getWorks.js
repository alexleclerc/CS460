function getWorks(id){
    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: "Home/Genre/" + id,
            success: (function (data) { displayArt(data) })
        }
    );

    function displayArt(inData)
    {

    }
 }