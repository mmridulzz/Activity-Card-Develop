import React, { useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/notification";
import { Table } from 'antd';
import { Skeleton } from 'antd';
const columns = [
    {
        title: 'Meaasge',
        dataIndex: 'message',
        key: 'message',
       
    }
    
];
const Notification = ({ ...props }) => {
    
    useEffect(() => {
        console.log("Student1 call")
        const onSuccess=()=>
        {
            console.log("notifications updated")
        }
        const val = { "Readstatus": "yes", "NUserId": localStorage.getItem('userid')}
        props.updateNotification(localStorage.getItem('userid'), val, onSuccess)
        props.fetchAllNotification(localStorage.getItem('userid'))
    }, [])
    if (props.Loading == true) { return <Skeleton active /> }
    if (!Array.isArray(props.notificationList)) { return <Skeleton active /> }
    return (<div className="site-layout-background" style={{ padding: 24, textAlign: 'center' }}>
        <Table dataSource={props.notificationList} columns={columns} />
    </div>
    );
}

const mapStateToProps = state => ({
    notificationList: state.notifications.list,
    Loading: state.notifications.loading,
})

const mapActionToProps = {

    fetchAllNotification: actions.fetchAll,
    updateNotification: actions.update
}

export default connect(mapStateToProps, mapActionToProps)(Notification);