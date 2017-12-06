function getBids(id) {
    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: "/Items/ItemBids/" + id,
            success: (function (data) { displayBids(data) })
        }
    );
}

    function displayBids(inData)
    {
        $("#displayContainer").empty();
        //create a string for the start of our table
        var tableHTML = "<table class = \"table\"><thead><tr><th>Price</th><th>Timestamp</th></tr></thead><tbody>";

        $.each(inData, function (i, name) {
          //  $("#displayContainer").append(
            tableHTML += "<tr>"
                + "<td>"
                + name["Price"]
                + "</td>"
                + "<td>"
          
                +name["TimeStamp"] 
                + "</td>"
                + "</tr>";
        });
        tableHTML += "</tbody></table>";
        $("#displayContainer").append(tableHTML);

    }