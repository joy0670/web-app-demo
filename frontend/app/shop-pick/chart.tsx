'use client';

import React, { useState, useEffect } from 'react';
import { Card, AreaChart, Title, Text } from '@tremor/react';

function formatNumberForDisplay(number) {
  return Intl.NumberFormat('us').format(number).toString();
}


export default function Example() {
  const [chartData, setChartData] = useState<any[]>([]);

  useEffect(() => {
    
    async function fetchData() {
      try {
        const response = await fetch("https://localhost:7032/api/barshoppick");
        if (!response.ok) {
          throw new Error(`Failed to fetch data with status: ${response.status}`);
        }
        const data = await response.json();
        console.log('Fetched data:', data);
        setChartData(data);
      } catch (error) {
        console.error("There was an error fetching the data:", error);
      }
    }
    
    fetchData();
  }, []);


  return (
    <Card>
      <Title>Performance</Title>
      <Text>Output per hour</Text>
      <AreaChart
        className="mt-4 h-80"
        data={chartData}
        categories={['qty']}
        index="houR_QUARTER"
        colors={['indigo', 'fuchsia']}
        valueFormatter={formatNumberForDisplay}
        yAxisWidth={60}
      />

    </Card>
  );
}
