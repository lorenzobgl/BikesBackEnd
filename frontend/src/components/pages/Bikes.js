import React, { useState } from 'react'
import '../assets/css/bikes.css'
import Constant from '../assets/Constants'


export default function Bikes() {
    function getBikes() {
        const url = Constant.API_URL_GET_ALL_BIKES
        fetch(url, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                setBikes(responseFromServer)
            })
            .catch((error) => {
                console.log(error)
                alert(error);
            })
    }
    function changeLock(id){
        const url = `${Constant.API_URL_LOCK_UNLOCK_BIKE}/${id}`
         fetch(url,{
            method:"PATCH",
            headers: {
                'Content-Type': 'application/json'
            },    
        }).then(getBikes()); 
    }

    function deleteBike(id){
        const url = `${Constant.API_URL_DELETE_BIKE}/${id}`
         fetch(url, {
            method: "DELETE",

        })
        getBikes();
    }
    const [bikes,setBikes]= useState([]);
  return (
    <>
    <button onClick={getBikes}>Genera Lista</button>
      <div className="table-responsive mt-5">
          <table className="table table-dark border-light">
              <thead>
                  <tr>
                      <th>Id</th>
                      <th>Tipo</th>
                      <th>Stato</th>
                      <th>Disponibilita</th>
                      <th>Operations</th>
                  </tr>
              </thead>
              <tbody>
                  {bikes.map((bike) => (
                      <tr key={bike.id} >
                          <th scope="row">{bike.id}</th>
                          <td>{bike.type}</td>
                          <td>{bike.isWorking?"Perfetto":"Rotto"}</td>
                          <td>{bike.lockOn?"Disponibile":"Non Disponibile"}</td>
                          <td className="">
                              <button className="btn btn-primary me-1" onClick={() => changeLock(bike.id)}>{bike.lockOn ? <i class="fa-solid fa-lock"></i> : <i class="fa-solid fa-lock-open"></i>}</button>
                              <button className="btn btn-danger ms-1" onClick={()=>deleteBike(bike.id)}><i class="fa-solid fa-trash"></i></button>
                          </td>
                      </tr>
                  ))}
              </tbody>
          </table>
      </div>
    </>
  )
}
