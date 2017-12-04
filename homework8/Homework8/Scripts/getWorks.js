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
        var tableHTML = "<table class = \"table\"><thead><tr><th>Title</th><th>First Name</th><th>Middle Name</th><th>Last Name</th></tr></thead><tbody>";

        //$("#displayContainer").append(tableStart);
        //$("#displayContainer").append(tableHead);
        $.each(inData, function (i, name) {
          //  $("#displayContainer").append(
                tableHTML += "<tr>"
                + "<td>"
                + name["Title"]
                + "</td>"
                + "<td>"
                + name["FirstName"]
                + "</td>"
                + "<td>"
                + name["MiddleName"]
                + "</td>"
                + "<td>"
                + name["LastName"]
                + "</td>"
                + "</tr>";
        });
        tableHTML += "</tbody></table>";
        $("#displayContainer").append(tableHTML);

    }