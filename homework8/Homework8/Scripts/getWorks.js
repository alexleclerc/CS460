function getWorks(id) {
    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: "/Home/Genre/" + id,
            success: (function (data) { displayArt(data) })
        }
    );
}

    function displayArt(inData)
    {
        $("#displayContainer").empty();
        //create a string for the start of our table
        var tableHTML = "<table class = \"table\"><thead><tr><th>Title</th><th>Artist</th></tr></thead><tbody>";

        //$("#displayContainer").append(tableStart);
        //$("#displayContainer").append(tableHead);
        $.each(inData, function (i, name) {
          //  $("#displayContainer").append(
            tableHTML += "<tr>"
                + "<td>"
                + name["Title"]
                + "</td>"
                + "<td>";
            if (name["FirstName"] == null) {
                tableHTML += "";
            }
            else
            {
                tableHTML += name["FirstName"] + " ";
            }
            if (name["MiddleName"] == null) {
                tableHTML += "";
            }
            else {
                tableHTML += name["MiddleName"] + " ";
            }
              
                tableHTML += name["LastName"]
                + "</td>"
                + "</tr>";
        });
        tableHTML += "</tbody></table>";
        $("#displayContainer").append(tableHTML);

    }