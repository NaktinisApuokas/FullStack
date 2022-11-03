import React from 'react'

export default function UpdateForm(props) {
    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Item Details "{props.item.title}".</h1>

            <div className="mt-5">
                <label className="h3 form-label">Item name</label>
                <input value={props.item.Name} name="title" type="text" className="form-control" />
            </div>

            <div className="mt-4">
                <label className="h3 form-label">Item information</label>
                <input value={props.item.Information} name="content" type="text" className="form-control" />
            </div>

        </form>
    );
}
