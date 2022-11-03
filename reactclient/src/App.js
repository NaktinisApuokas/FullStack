import React, {useState} from "react";
import axios from 'axios';
import ItemCreateForm from "./components/ItemCreateForm";
import ItemDetailsForm from "./components/ItemDetailsForm";

export default function App() {
  const [showingCreateItem, setshowingCreateItem] = useState(false);
  const [ShowingItem, ShowItem] = useState(null);

  function getPosts() {
    axios.get('http://localhost:5148/api/cinemas')
    .then(response => {
      renderRecords(response.data)
    })
  }

  return (
    <div className="list">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h1> Full-stack Academy Qualification task</h1>
          <div className="mt-5">
            <button onClick={() => setshowingCreateItem(true)} className="btn btn-dark btn-lg w-100">Add Item </button>
          </div>
          {(showingCreateItem === false && ShowingItem === null) && renderRecords()}
          {showingCreateItem && <ItemCreateForm onItemCreated={onItemCreated} />}
          {ShowingItem !== null && <ItemDetailsForm item={ShowingItem}/>}
        </div>
      </div>
    </div>
  );
  function onItemCreated(createdItem) {
    setshowingCreateItem(false);

    if (createdItem === null) {
      return;
    }

    alert(`Item successfully created. After clicking OK, your new item named "${createdItem.Name}" will show up in the table below.`);

    getPosts();
  }

  function renderRecords(items){
    return (
      <div className="table-resposive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Name</th>
              <th scope="col">Information</th>
              <th scope="col">Show details</th>
            </tr>
          </thead>
          <tbody>
          {items?.map(item => (
              <tr key={item.Id}>
                <th scope="row">{item.Id}</th>
                <td>{item.Name}</td>
                <td>{item.Information}</td>
                <td>
                  <button onClick={() => ShowItem(item)} className="btn btn-dark btn-lg mx-3 my-3">Show details</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    )
  }

}

