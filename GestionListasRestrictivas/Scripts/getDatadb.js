

var html5rocks = {};
html5rocks.webdb = {};

html5rocks.webdb.db = null;


html5rocks.webdb.open = function () {
    var dbSize = 5 * 1024 * 1024; // 5MB
    html5rocks.webdb.db = openDatabase("Pacientes", "1", "Pacientes DB", dbSize);    
}

html5rocks.webdb.onError = function (tx, e) {
    alert("There has been an error: " + e.message);
}

html5rocks.webdb.onSuccess = function (tx, r) {
    // re-render the data.
    // loadTodoItems is defined in Step 4a
    html5rocks.webdb.getPacState(loadTodoItems);
};


html5rocks.webdb.createTable = function () {
    var db = html5rocks.webdb.db;
    db.transaction(function (tx) {
        tx.executeSql("CREATE TABLE IF NOT EXISTS " +
            "CircuitoPac(ID INTEGER PRIMARY KEY ASC, nhc str, state str)", []);
    });
};

html5rocks.webdb.addTodo = function (nhc, state) {
    var db = html5rocks.webdb.db;
    db.transaction(function (tx) {
        var addedOn = new Date();
        tx.executeSql("INSERT INTO CircuitoPac(todo, state) VALUES (?,?)",
            [nhc, state],
            html5rocks.webdb.onSuccess,
            html5rocks.webdb.onError);
    });
};


html5rocks.webdb.getAllTodoItems = function (renderFunc) {
    var db = html5rocks.webdb.db;
    db.transaction(function (tx) {
        tx.executeSql("SELECT * FROM CircuitoPac", [], renderFunc,
            html5rocks.webdb.onError);
    });
};

function loadTodoItems(tx, rs) {
    var rowOutput = "";

    for (var i = 0; i < rs.rows.length; i++) {
        rowOutput += renderTodo(rs.rows.item(i));
    }

    todoItems.innerHTML = rowOutput;
}

html5rocks.webdb.getPacState = function (nhc, renderFunc) {
    var db = html5rocks.webdb.db;
    db.transaction(function (tx) {
        tx.executeSql("SELECT nhc, state FROM CircuitoPac  WHERE NHC=?", [nhc], renderFunc,
            html5rocks.webdb.onError);
    });
};

function getPatientState(tx, rs) {
    var rowOutput = "";

    if (  rs.rows.length > 0) {
        rowOutput = renderTodo(rs.rows);
    }

    var NHC =  rowOutput;
}


function renderTodo(row) {
    return   row.todo ;
};

html5rocks.webdb.deleteTodo = function (nhc) {
    var db = html5rocks.webdb.db;
    db.transaction(function (tx) {
        tx.executeSql("DELETE FROM todo CircuitoPac nhc=?", [nhc],
            html5rocks.webdb.onSuccess,
            html5rocks.webdb.onError);
    });
};

function init() {
    html5rocks.webdb.open();
    html5rocks.webdb.createTable();
    html5rocks.webdb.getPacState(getPatientState);
}