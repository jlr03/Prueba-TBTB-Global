import React from 'react';

const TableWorker = (data) =>{

    let users = data.data;

    return(
        <>
           <div className="container">
                <div className="row">
                    <div className="col-12 col-lg-12 table-responsive py-4">
                        <table className="table table-bordered border-secondary table-hover">
                            <thead>
                                <tr className="table-primary border-secondary">
                                    <th scope="col">Id</th>
                                    <th scope="col">Name</th>
                                    <th scope="col">Username</th>
                                    <th scope="col">Email</th>
                                    <th scope="col">Street</th>
                                    <th scope="col">Suite</th>
                                    <th scope="col">City</th>
                                    <th scope="col">Zipcode</th>
                                    <th scope="col ">Ubication</th>
                                    <th scope="col">Phone</th>
                                    <th scope="col">Website</th>
                                    <th scope="col">Company</th>
                                    <th scope="col">Phrase</th>
                                    <th scope="col">BS</th>
                                </tr>
                            </thead>
                            {users.length === 0 ? (
                                <tbody>
                                    <tr>
                                         No se encontaron datos
                                    </tr>
                                </tbody>
                            ) : (
                                users.map((item, index) => (
                                    <tbody key={index}>
                                        <tr className="align-middle">
                                            <th scope="row">{item.id}</th>
                                            <td>{item.name}</td>
                                            <td>{item.username}</td>
                                            <td>{item.email}</td>
                                            <td>{item.address.street}</td>
                                            <td>{item.address.suite}</td>
                                            <td>{item.address.city}</td>
                                            <td>{item.address.zipcode}</td>
                                            <td>{item.address.geo.lat},{item.address.geo.lng}</td>
                                            <td>{item.phone}</td>
                                            <td>{item.website}</td>
                                            <td>{item.company.name}</td>
                                            <td>{item.company.catchPhrase}</td>
                                            <td>{item.company.bs}</td>
                                        </tr>
                                    </tbody>
                                ))
                            )}
                        </table>
                    </div>
                </div>
            </div>
        </>   
    )
}

export default TableWorker;