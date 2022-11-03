import React, {useState} from "react";

export default function App() {
  const [record, setRecord] = useState([]);

  function getPosts() {
    const url = 'http://localhost:5155/get-all-posts';

    fetch(url, {method: 'GET'})
    .then(Response => Response.json())
    .then(recordFromServer => {console.log(recordFromServer);setRecord(recordFromServer);})
    .catch((error) => {console.log(error); alert(error);});
  }

  function Addrecord() {

  }
  return (
    <div className="list">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h1> Full-stack Academy Qualification task</h1>
          <div className="mt-5">
            <button onClick={Addrecord} className="btn btn-dark btn-lg w-100">Add Record</button>
            <button onClick={getPosts} className="btn btn-secondary btn-lg w-100">Get Record</button>
          </div>
          {renderRecords()}
        </div>
      </div>
    </div>
  );

  function renderRecords(){
    return (
      <div className="table-resposive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Name</th>
              <th scope="col">Information</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <th>Name1</th>
              <th>Information1</th>
            </tr>
          </tbody>
        </table>
      </div>
    )
  }

}

